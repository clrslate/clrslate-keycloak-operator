using k8s;
using k8s.Models;
using KubeOps.Operator.Controller.Results;
using MediatR;

namespace KeyCloakOperator.Extensions.MediatR
{
    public static class MediatorExtensions
    {
        public static Task<ResourceControllerResult?> OnReconciled<TEntity>(this IMediator mediator, TEntity entity)
            where TEntity : IKubernetesObject<V1ObjectMeta>
        {
            var reconciledCommand = new OnReconciled<TEntity>(entity);
            return mediator.Send(reconciledCommand);
        }
    }
}
