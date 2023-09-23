using k8s.Models;
using k8s;
using KubeOps.Operator.Controller.Results;

namespace KeyCloakOperator.Managers
{
    public interface IManager<TEntity> where TEntity : IKubernetesObject<V1ObjectMeta>
    {
        Task<ResourceControllerResult?> ReconcileAsync(TEntity entity);

        Task StatusModifiedAsync(TEntity entity);

        Task DeletedAsync(TEntity entity);

        Task FinalizedAsync(TEntity entity);
    }
}
