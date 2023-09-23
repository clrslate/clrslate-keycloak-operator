using k8s;
using k8s.Models;
using KubeOps.Operator.Controller.Results;
using MediatR;

namespace KeyCloakOperator.Extensions.MediatR
{
    public class OnReconciled<TEntity> : IRequest<ResourceControllerResult?>
        where TEntity : IKubernetesObject<V1ObjectMeta>
    {
        public OnReconciled(TEntity entity) => Entity = entity;

        public TEntity Entity { get; }
    }
}
