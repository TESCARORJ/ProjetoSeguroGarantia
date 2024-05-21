using MongoDB.Driver;
using ProjetoSeguroGarantia.Infra.Storage.Collections;
using ProjetoSeguroGarantia.Infra.Storage.Settings;

namespace ProjetoSeguroGarantia.Infra.Storage.Contexts
{
    /// <summary>
    /// Classe de contexto para acesso ao MongoDB
    /// </summary>
    public class MongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;
            Configure();
        }

        private IMongoDatabase? _mongoDatabase;

        private void Configure()
        {
            //configurando o endereço do servidor do BD (connectionstring)
            var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings?.Host));

            //verificando se a conexão é do tipo SSL
            if (_mongoDBSettings.IsSSL)
                mongoClientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            //conectando com o banco de dados
            var mongoClient = new MongoClient(mongoClientSettings);
            _mongoDatabase = mongoClient.GetDatabase(_mongoDBSettings.Database);
        }

        //Mapeamento das collections do banco
        public IMongoCollection<SeguroGarantiaCollection> SeguroGarantia
            => _mongoDatabase.GetCollection<SeguroGarantiaCollection>("BDSeguroGarantia");
    }
}
