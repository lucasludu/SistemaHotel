using SistemaHotel.EF.Contexto;
using SistemaHotel.Negocios.Context;

namespace SistemaHotel.Negocios.Contexto
{
    public abstract class BLLContext : IDisposable
    {
        protected HotelContext Context;
        public BLLContext()
        {
            EFStringConnection.GetStringConnection();
            this.Context = new HotelContext(EFStringConnection.stringConnection!);
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
