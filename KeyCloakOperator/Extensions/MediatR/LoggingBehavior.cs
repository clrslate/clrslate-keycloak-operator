using k8s;
using k8s.Models;
using MediatR;

namespace KeyCloakOperator.Extensions.MediatR
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!LoggingBehavior<TRequest, TResponse>.IsReconciledEntity()) return await next();

            var resource = LoggingBehavior<TRequest, TResponse>.ToKubernetesObject(request);
            if (resource != null)
            {
                _logger.LogInformation("Reconciliation started for {Kind}.{Name}", resource.Kind, resource.Metadata.Name);
                _logger.LogDebug("Desired State: {resource}", resource);
            }

            return await next();
        }
        
        #region Private static helpers

        private static Type onReconciledType = typeof(OnReconciled<>);
        private static IKubernetesObject<V1ObjectMeta>? ToKubernetesObject(TRequest request)
            => ((dynamic)request).Entity as IKubernetesObject<V1ObjectMeta>;

        private static bool IsReconciledEntity()
            => typeof(TRequest).IsGenericType && typeof(TRequest).GetGenericTypeDefinition().IsAssignableFrom(onReconciledType); 

        #endregion
    }
}
