namespace Orleans.Persistence.RavenDB.Provider
{
    internal enum RavenDBProviderErrorCode
    {
        ProvidersBase = 200000,

        // RavenDB storage provider related
        RavenDBProviderBase = ProvidersBase + 1100,
        RavenDBProvider_DataNotFound = RavenDBProviderBase + 1,
        RavenDBProvider_ReadingData = RavenDBProviderBase + 2,
        RavenDBProvider_WritingData = RavenDBProviderBase + 3,
        RavenDBProvider_Storage_Reading = RavenDBProviderBase + 4,
        RavenDBProvider_Storage_Writing = RavenDBProviderBase + 5,
        RavenDBProvider_Storage_DataRead = RavenDBProviderBase + 6,
        RavenDBProvider_WriteError = RavenDBProviderBase + 7,
        RavenDBProvider_DeleteError = RavenDBProviderBase + 8,
        RavenDBProvider_InitProvider = RavenDBProviderBase + 9,
        RavenDBProvider_ParamConnectionString = RavenDBProviderBase + 10,
    }
}
