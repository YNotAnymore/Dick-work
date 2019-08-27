
# Odata #

#### construction ####

	ODataClient client = new ODataClient(baseUri);

navigation>

	public ODataClient(string baseUri)
      : this(new ODataClientSettings()
      {
        BaseUri = new Uri(baseUri)
      })
    {
    }


----------

	/// <summary>
    /// Initializes a new instance of the <see cref="T:Simple.OData.Client.ODataClientSettings" /> class.
    /// </summary>
    /// <param name="baseUri">The URL address.</param>
    /// <param name="credentials">The client credentials.</param>
    public ODataClientSettings(Uri baseUri, ICredentials credentials = null)
    {
      this.BaseUri = baseUri;
      this.Credentials = credentials;
    }

----------

	public ODataClient(ODataClientSettings settings)
    {
      this._settings = settings;
      this._session = Session.FromSettings(this._settings);
      this._requestRunner = new RequestRunner((ISession) this._session);
    }

navigation Simple.OData.Client.Session.FromSettings

	internal static Session FromSettings(ODataClientSettings settings)
    {
      return new Session(settings);
    }

----------

	private Session(ODataClientSettings settings)
    {
      if (settings.BaseUri == (Uri) null || string.IsNullOrEmpty(settings.BaseUri.AbsoluteUri))
        throw new InvalidOperationException("Unable to create client session with no URI specified");
      this._adapterFactory = new AdapterFactory((ISession) this);
      this._createAdapter = (Func<IODataAdapter>) (() => this._adapterFactory.ParseMetadata(this.MetadataCache.MetadataDocument));
      this.Settings = settings;
      this.MetadataCache = MetadataCache.Instances.GetOrAdd(this.Settings.BaseUri.AbsoluteUri, new MetadataCache());
      this.Pluralizer = (IPluralizer) new SimplePluralizer();
    }

#### use ####

	await client
		.For<Supplier>()
		.OrderBy(s => s.SupplierNo)
		.FindEntriesAsync();


navigation Simple.OData.Client.ODataClient.For

	/// <summary>
    /// Returns an instance of a fluent OData client for the specified collection.
    /// </summary>
    /// <param name="collectionName">Name of the collection.</param>
    /// <returns>The fluent OData client instance.</returns>
    public IBoundClient<IDictionary<string, object>> For(
      string collectionName)
    {
      return this.GetBoundClient().For(collectionName);
    }


----------

### GetBoundClient ###

    private BoundClient<IDictionary<string, object>> GetBoundClient()
    {
      return new BoundClient<IDictionary<string, object>>(this, this._session, (FluentCommand) null, (FluentCommand) null, false);
    }

查看构造

	internal BoundClient(
      ODataClient client,
      Session session,
      FluentCommand parentCommand = null,
      FluentCommand command = null,
      bool dynamicResults = false)
      : base(client, session, parentCommand, command, dynamicResults)
    {
    }

查看相应的base构造

	internal FluentClientBase(
      ODataClient client,
      Session session,
      FluentCommand parentCommand = null,
      FluentCommand command = null,
      bool dynamicResults = false)
    {
      this._client = client;
      this._session = session;
      this._parentCommand = parentCommand;
      this._command = command;
      this._dynamicResults = dynamicResults;
    }

故**GetBoundClient**即只是重新构建一个**BoundClient**对象并返回

构造时仅对属性赋值

----------

to Simple.OData.Client.BoundClient.For

    public IBoundClient<T> For(string collectionName = null)
    {
      this.Command.For(collectionName ?? this.Command.TypeCache.GetMappedName(typeof (T)));
      return (IBoundClient<T>) this;
    }

查看属性Command的定义

    internal FluentCommand Command
    {
      get
      {
        if (this._command != null)
          return this._command;
        lock (this)
          return this._command ?? (this._command = this.CreateCommand());
      }
    }

通过对**GetBoundClient**的分析可知**_command**默认为null

查看**CreateCommand**定义：

    protected FluentCommand CreateCommand()
    {
      return new FluentCommand(this.Session, this._parentCommand, this._client.BatchEntries);
    }

	internal FluentCommand(
      Session session,
      FluentCommand parent,
      ConcurrentDictionary<object, IDictionary<string, object>> batchEntries)
    {
      this._details = new CommandDetails(session, parent, batchEntries);
    }

	public CommandDetails(
      Session session,
      FluentCommand parent,
      ConcurrentDictionary<object, IDictionary<string, object>> batchEntries)
    {
      this.Session = session;
      this.Parent = parent;
      this.SkipCount = -1L;
      this.TopCount = -1L;
      this.ExpandAssociations = new List<KeyValuePair<string, ODataExpandOptions>>();
      this.SelectColumns = new List<string>();
      this.OrderbyColumns = new List<KeyValuePair<string, bool>>();
      this.MediaProperties = (IEnumerable<string>) new List<string>();
      this.BatchEntries = batchEntries;
    }

简单的属性赋值，了解。

deep Simple.OData.Client.FluentCommand.For

    public FluentCommand For(string collectionName)
    {
      if (this.IsBatchResponse)
        return this;
      string[] strArray = collectionName.Split('/');
      if (((IEnumerable<string>) strArray).Count<string>() > 1)
      {
        this._details.CollectionName = strArray[0];
        this._details.DerivedCollectionName = strArray[1];
      }
      else
        this._details.CollectionName = collectionName;
      return this;
    }

**For方法**：构建了一个**BoundClient**，然后通过这个对象构建一个**FluentCommand**，再在**FluentCommand**中构建了一个**CommandDetails**

最终给**CommandDetails**的属性进行赋值

----------

- OrderBy

	类似于For，除了构建部分，因为For已经基本上构建了所有基本对象

### FindEntriesAsync ###

to Simple.OData.Client.BoundClient.FindEntryAsync

	public Task<T> FindEntryAsync()
    {
      return this.FindEntryAsync(CancellationToken.None);
    }

	public Task<T> FindEntryAsync(CancellationToken cancellationToken)
    {
      return this.FilterAndTypeColumnsAsync(
      this._client.FindEntryAsync(this._command, cancellationToken),
      this._command.SelectedColumns, this._command.DynamicPropertiesContainerName);
    }

----------

Simple.OData.Client.ODataClient.FindEntryAsync

    internal async Task<IDictionary<string, object>> FindEntryAsync(
      FluentCommand command,
      CancellationToken cancellationToken)
    {
      if (this.IsBatchResponse)
        return this._batchResponse.AsEntry(false);
      IODataAdapter odataAdapter = await this._session.ResolveAdapterAsync(cancellationToken).ConfigureAwait(false);
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();
      string commandText = await command.GetCommandTextAsync(cancellationToken).ConfigureAwait(false);
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();
      IEnumerable<AnnotatedEntry> source = await this.FindAnnotatedEntriesAsync(commandText, false, (ODataFeedAnnotations) null, cancellationToken).ConfigureAwait(false);
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();
      AnnotatedEntry result = source != null ? source.FirstOrDefault<AnnotatedEntry>() : (AnnotatedEntry) null;
      await this.EnrichWithMediaPropertiesAsync(result, command.Details.MediaProperties, cancellationToken).ConfigureAwait(false);
      return result?.GetData(this._session.Settings.IncludeAnnotationsInResults);
    }

----------


- 