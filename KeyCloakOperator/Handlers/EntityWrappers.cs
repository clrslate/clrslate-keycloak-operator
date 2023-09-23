using KeyCloakOperator.Entities;
using KeyCloakOperator.Extensions.MediatR;
using KubeOps.Operator.Controller.Results;

namespace KeyCloakOperator.Handlers
{
    public class OnTestEntityReconciled : IKubernetesEntityHandler<V1KeyCloakClientEntity>
    {
        public Task<ResourceControllerResult?> Handle(V1KeyCloakClientEntity request, CancellationToken cancellationToken)
        {
            return Task.FromResult<ResourceControllerResult?>(null);
        }
    }
}
