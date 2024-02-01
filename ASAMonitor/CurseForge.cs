using System;
using System.Collections.Generic;

namespace ASAMonitor.CurseForge
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public int gameId { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string iconUrl { get; set; }
        public DateTime dateModified { get; set; }
        public bool isClass { get; set; }
        public int classId { get; set; }
        public int parentCategoryId { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public int gameId { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public Links links { get; set; }
        public string summary { get; set; }
        public int status { get; set; }
        public int downloadCount { get; set; }
        public bool isFeatured { get; set; }
        public int primaryCategoryId { get; set; }
        public List<Category> categories { get; set; }
        public int classId { get; set; }
        public List<Author> authors { get; set; }
        public Logo logo { get; set; }
        public List<Screenshot> screenshots { get; set; }
        public int mainFileId { get; set; }
        public List<LatestFile> latestFiles { get; set; }
        public int supportedPlatform { get; set; }
        public bool supportsCrossPlatform { get; set; }
        public List<LatestFilesIndex> latestFilesIndexes { get; set; }
        public List<object> latestEarlyAccessFilesIndexes { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public DateTime dateReleased { get; set; }
        public bool allowModDistribution { get; set; }
        public int gamePopularityRank { get; set; }
        public bool isAvailable { get; set; }
        public int thumbsUpCount { get; set; }
        public string displayName { get { return string.Format("{0} {1}", id, name);  } }
    }

    public class Hash
    {
        public string value { get; set; }
        public int algo { get; set; }
    }

    public class LatestFile
    {
        public int id { get; set; }
        public int gameId { get; set; }
        public int modId { get; set; }
        public bool isAvailable { get; set; }
        public string displayName { get; set; }
        public string fileName { get; set; }
        public int releaseType { get; set; }
        public int fileStatus { get; set; }
        public List<Hash> hashes { get; set; }
        public DateTime fileDate { get; set; }
        public long fileLength { get; set; }
        public int downloadCount { get; set; }
        public long fileSizeOnDisk { get; set; }
        public string downloadUrl { get; set; }
        public List<string> gameVersions { get; set; }
        public List<SortableGameVersion> sortableGameVersions { get; set; }
        public List<object> dependencies { get; set; }
        public int alternateFileId { get; set; }
        public bool isServerPack { get; set; }
        public object fileFingerprint { get; set; }
        public List<Module> modules { get; set; }
    }

    public class LatestFilesIndex
    {
        public string gameVersion { get; set; }
        public int fileId { get; set; }
        public string filename { get; set; }
        public int releaseType { get; set; }
        public int gameVersionTypeId { get; set; }
    }

    public class Links
    {
        public string websiteUrl { get; set; }
        public string wikiUrl { get; set; }
        public string issuesUrl { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Logo
    {
        public int id { get; set; }
        public int modId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnailUrl { get; set; }
        public string url { get; set; }
    }

    public class Module
    {
        public string name { get; set; }
        public object fingerprint { get; set; }
    }

    public class Pagination
    {
        public int index { get; set; }
        public int pageSize { get; set; }
        public int resultCount { get; set; }
        public int totalCount { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
        public Pagination pagination { get; set; }
    }

    public class Screenshot
    {
        public int id { get; set; }
        public int modId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnailUrl { get; set; }
        public string url { get; set; }
    }

    public class SortableGameVersion
    {
        public string gameVersionName { get; set; }
        public string gameVersionPadded { get; set; }
        public string gameVersion { get; set; }
        public DateTime gameVersionReleaseDate { get; set; }
        public int gameVersionTypeId { get; set; }
    }

}