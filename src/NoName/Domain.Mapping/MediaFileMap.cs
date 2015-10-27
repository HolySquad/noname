namespace Domain.Mapping
{
    public class MediaFileMap : EntityMap<MediaFile>
    {
        public MediaFileMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Path).Not.Nullable();
        }
    }
}