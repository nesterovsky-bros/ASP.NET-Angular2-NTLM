namespace Hapoalim.CreditRatings
{
  using System;
  using System.IO;
  using System.Net.Http;

  using Microsoft.Extensions.FileProviders;
  using Microsoft.Extensions.Primitives;

  public class UrlFileProvider: IFileProvider
  {
    public UrlFileProvider(string baseUrl)
    {
      BaseUrl = baseUrl;
    }

    public string BaseUrl { get; private set; }

    public HttpClient Client { get; } = new HttpClient();


    public IDirectoryContents GetDirectoryContents(string subpath)
    {
      throw new NotImplementedException();
    }

    public IFileInfo GetFileInfo(string subpath)
    {
      return new UrlFileInfo(this, subpath);
    }

    public IChangeToken Watch(string filter)
    {
      throw new NotImplementedException();
    }
  }

  public class UrlFileInfo: IFileInfo
  {
    public UrlFileInfo(UrlFileProvider fileProvider, string subpath)
    {
      FileProvider = fileProvider;
      SubPath = subpath;
    }

    public UrlFileProvider FileProvider { get; private set; }

    public string SubPath { get; private set; }

    public bool Exists
    {
      get { return Data != null; }
    }

    public bool IsDirectory
    {
      get { return false; }
    }

    public DateTimeOffset LastModified
    {
      get { return DateTimeOffset.Now; }
    }

    public long Length
    {
      get { return Data?.Length ?? 0; }
    }

    public string Name
    {
      get { return SubPath; }
    }

    public string PhysicalPath
    {
      get { return SubPath; }
    }

    public Stream CreateReadStream()
    {
      return new MemoryStream(Data ?? new byte[0]);
    }

    public byte[] Data
    {
      get
      {
        if (!dataInitialized)
        {
          try
          {
            data = FileProvider.Client.GetByteArrayAsync(
              new Uri(new Uri(FileProvider.BaseUrl), SubPath)).Result;
          }
          catch
          {
          }

          dataInitialized = true;
        }

        return data;
      }
    }

    private bool dataInitialized;
    private byte[] data;
  }
}
