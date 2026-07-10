namespace RaseTheSun.Scripts.GameLogic.Attachment
{
    public abstract class AttachmentStatsDecorator : IAttachmentStatsProvider
    {
        protected readonly IAttachmentStatsProvider WrappedEntity;

        protected AttachmentStatsDecorator(IAttachmentStatsProvider wrappedEntity) =>
            WrappedEntity = wrappedEntity;

        public AttachmentStats GetStats() =>
            GetStatsInternal();

        protected abstract AttachmentStats GetStatsInternal();
    }
}
