
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

> await client.For<Supplier>().OrderBy(s => s.SupplierNo).FindEntriesAsync();

	await client.For<Supplier>().OrderBy(s => s.SupplierNo).FindEntriesAsync();


navigation Simple.OData.Client.ODataClient.For

	/// <summary>
    /// Returns an instance of a fluent OData client for the specified collection.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="collectionName">Name of the collection.</param>
    /// <returns>The fluent OData client instance.</returns>
    public IBoundClient<T> For<T>(string collectionName = null) where T : class
    {
      return new BoundClient<T>(this, this._session, (FluentCommand) null, (FluentCommand) null, false).For(collectionName);
    }


----------

	internal BoundClient(
      ODataClient client,
      Session session,
      FluentCommand parentCommand = null,
      FluentCommand command = null,
      bool dynamicResults = false)
      : base(client, session, parentCommand, command, dynamicResults)
    {
    }


----------

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

通过OataClient构造BoundClient，通过构造初始化父类(FluentClientBase)的字段

to Simple.OData.Client.BoundClient.OrderBy

	public IBoundClient<T> OrderBy(IEnumerable<KeyValuePair<string, bool>> columns)
    {
      this.Command.OrderBy(columns);
      return (IBoundClient<T>) this;
    }


----------

	public FluentCommand OrderBy(IEnumerable<KeyValuePair<string, bool>> columns)
    {
      if (this.IsBatchResponse)
        return this;
      this._details.OrderbyColumns.AddRange(this.SplitItems(columns));
      return this;
    }

通过list字段保存相应的条件、排序等

to Simple.OData.Client.BoundClient.FindEntriesAsync

	public Task<IEnumerable<T>> FindEntriesAsync()
    {
      return this.FindEntriesAsync(CancellationToken.None);
    }


----------

	public Task<IEnumerable<T>> FindEntriesAsync(CancellationToken cancellationToken)
    {
      return this.RectifyColumnSelectionAsync(
        this._client.FindEntriesAsync(this._command, cancellationToken),
        this._command.SelectedColumns, 
        this._command.DynamicPropertiesContainerName
        );
    }

to Simple.OData.Client.ODataClient.FindEntriesAsync

	internal async Task<IEnumerable<IDictionary<string, object>>> FindEntriesAsync(
      FluentCommand command,
      CancellationToken cancellationToken)
    {
      if (this.IsBatchResponse)
        return this._batchResponse.AsEntries();
      IODataAdapter odataAdapter = await this._session.ResolveAdapterAsync(cancellationToken);
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();
      string commandText = await command.GetCommandTextAsync(cancellationToken);
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();
      return await this.FindEntriesAsync(commandText, cancellationToken);
    }

to Simple.OData.Client.FluentCommand.GetCommandTextAsync

	public async Task<string> GetCommandTextAsync(CancellationToken cancellationToken)
    {
      IODataAdapter odataAdapter = await this._details.Session.ResolveAdapterAsync(cancellationToken);
      return new FluentCommand(this).Resolve().Format();
    }

to Simple.OData.Client.Session.ResolveAdapterAsync

	public async Task<IODataAdapter> ResolveAdapterAsync(
      CancellationToken cancellationToken)
    {
      if (!this.MetadataCache.IsResolved())
      {
        IODataAdapter adapter;
        if (string.IsNullOrEmpty(this.Settings.MetadataDocument))
        {
          HttpResponseMessage response = await this.SendMetadataRequestAsync(cancellationToken);
          this.MetadataCache.SetMetadataDocument(await this._adapterFactory.GetMetadataDocumentAsync(response));
          adapter = await this._adapterFactory.CreateAdapterAsync(response);
        }
        else
        {
          this.MetadataCache.SetMetadataDocument(this.Settings.MetadataDocument);
          adapter = this._adapterFactory.CreateAdapter(this.Settings.MetadataDocument);
        }
        this._createAdapter = (Func<IODataAdapter>) (() => adapter);
      }
      if (this.Settings.PayloadFormat == ODataPayloadFormat.Unspecified)
        this.Settings.PayloadFormat = this.Adapter.DefaultPayloadFormat;
      return this.Adapter;
    }