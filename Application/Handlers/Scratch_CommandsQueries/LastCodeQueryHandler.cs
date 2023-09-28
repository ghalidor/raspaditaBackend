
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class LastCodeQueryHandler : IRequestHandler<LastCodeQuery, Scratch_codigo>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public LastCodeQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_codigo> Handle(LastCodeQuery query, CancellationToken cancellationToken)
        {
            Scratch_codigo nuevo = new Scratch_codigo();
            var puntojuego = await _puntoJuegoRepository.GetPuntoJuegoDetalle(query.puntojuego_id);


            var valor = await _scratchRepository.getLastCode(puntojuego.ip);
            if(valor.codigo==null)
            {
                nuevo.codigo = "sin conexion";
            }
            else
            {
                if (valor.codigo == "error")
                {
                    nuevo.codigo = "No hubo ticket desde qe se encendió el dispositivo";
                }
                else
                {
                    nuevo.codigo = valor.codigo;
                }
                
            }
            
            return nuevo;
        }

    }

}
