namespace ForTec.Domain.Interfaces;

public interface IMunicipioRepository
{
    Task<string> GetNameByCodIbge(int codigoIbge);
}
