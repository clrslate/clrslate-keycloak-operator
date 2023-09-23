using k8s;
using k8s.Models;
using KubeOps.Operator.Controller.Results;
using MediatR;

namespace KeyCloakOperator.Extensions.MediatR
{
    public interface IKubernetesEntityHandler<TEntity> :
        IRequestHandler<OnReconciled<TEntity>, ResourceControllerResult?>
            where TEntity : IKubernetesObject<V1ObjectMeta>
    {
        Task<ResourceControllerResult?> IRequestHandler<OnReconciled<TEntity>, ResourceControllerResult?>.Handle(
            OnReconciled<TEntity> request,
            CancellationToken cancellationToken) 
            => Handle(request.Entity, cancellationToken);

        Task<ResourceControllerResult?> Handle(TEntity request, CancellationToken cancellationToken);
    }
}
