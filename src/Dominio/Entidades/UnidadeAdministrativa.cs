using Dominio.Enums;

namespace Dominio.Entidades
{
    public class UnidadeAdministrativa
    {
        public int CodigoUnidadeAdministrativa { get; private set; }
        public string NomeUnidadeAdministrativa { get; private set; }
        public string Sigla { get; private set; }
        public bool OrgaoEx { get; private set; }
        public string UnidadeDaFederacao { get; private set; }
        public EhEsferaAdministrativa EsferaAdministrativa { get; private set; }
        public bool Ativo { get; private set; }

        public ItemParticipante ItemParticipante { get; private set; }
    }
}
