﻿// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Veam.FileStorage.Abstractions;
using Microsoft.Extensions.Options;

namespace Veam.FileStorage.FileSystem
{
  /// <summary>
  /// Implements the <see cref="IFileStorage">IFileStorage</see> interface and represents a file storage in a file system.
  /// </summary>
  public class FileStorage : IFileStorage
  {
    private readonly string rootPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileStorage">FileStorage</see> class.
    /// </summary>
    /// <param name="options">The options that are used to configure the file storage root path.</param>
    public FileStorage(IOptions<FileStorageOptions> options)
    {
      this.rootPath = options.Value.RootPath;
    }

    /// <summary>
    /// Creates a directory proxy which allows to manipulate an underlying directory with a specified relative path.
    /// </summary>
    /// <param name="relativePath">The path of the underlying directory relatively to the root one.</param>
    /// <returns>Created directory proxy.</returns>
    public IDirectoryProxy CreateDirectoryProxy(string relativePath)
    {
      return new DirectoryProxy(this.rootPath, relativePath);
    }

    /// <summary>
    /// Creates a file proxy which allows to manipulate an underlying file with a specified relative path and a filename.
    /// </summary>
    /// <param name="relativePath">The path of the underlying file relatively to the root one.</param>
    /// <param name="filename">The filename of the underlying file.</param>
    /// <returns>Created file proxy.</returns>
    public IFileProxy CreateFileProxy(string relativePath, string filename)
    {
      return new FileProxy(this.rootPath, relativePath, filename);
    }
  }
}