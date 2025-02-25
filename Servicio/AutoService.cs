using PersonasAutos.Dtos;
using PersonasAutos.Metodos;
using PersonasAutos.Models;

namespace PersonasAutos.Servicio
{
    public class AutoService:IMetodosAuto
    {
        private Practica2Context _contexto = new Practica2Context();

        public List<Auto> MostrarAutos()
        {
            return _contexto.Autos.ToList();
        }

        public Respuesta Guardar(Auto auto)
        {
            Respuesta rs = new Respuesta();
            if(_contexto.Autos.Find(auto.Matricula) != null)
            {
                rs.Mensaje = "El auto no se registro porque la matricula ya existe";
                rs.Success = false;
                rs.obj = auto;
                return rs;
            }
            foreach(Auto a in _contexto.Autos)
            {
                if(auto.Modelo == a.Modelo && auto.Marca == a.Marca && auto.Color == a.Color)
                {
                    rs.Mensaje = "El auto que tratas de guardar ya existe intente con otros datos";
                    rs.Success = false;
                    rs.obj = auto;
                    return rs;
                }
            }
            _contexto.Autos.Add(auto);
            _contexto.SaveChanges();
            rs.Mensaje = "El auto ha sido agregado a la base de datos";
            rs.Success = true;
            rs.obj = auto;
            return rs;
        }
        public Respuesta Editar(Auto auto)
        {
            Respuesta rs = new Respuesta();
            if (Buscar(auto.Matricula) == null)
            {
                rs.Mensaje = "El auto que tratas de editar no existe en la base de datos";
                rs.Success = false;
                rs.obj = auto.Matricula;
                return rs;
            }
            Auto auto_aux = Buscar(auto.Matricula);
            auto_aux.Marca = auto.Marca;
            auto_aux.Modelo = auto.Modelo;
            auto_aux.Color = auto.Color;
            auto_aux.Anio = auto.Anio;
            auto_aux.Peso = auto.Peso;
            auto_aux.Precio = auto.Precio;
            auto_aux.Tipo = auto.Tipo;
            auto_aux.CurpPersona = auto.CurpPersona;
            _contexto.SaveChanges();
            rs.Mensaje = "La auto ha sido editada";
            rs.Success = true;
            rs.obj = auto;
            return rs;
        }
        public Respuesta Eliminar(Auto auto)
        {
            Respuesta rs = new Respuesta();
            auto = Buscar(auto.Matricula);
            if(auto == null)
            {
                rs.Mensaje = "El auto que tratas de eliminar no existe en la base de datos";
                rs.Success = false;
                rs.obj = null;
                return rs;
            }
            rs.obj = auto;
            _contexto.Autos.Remove(auto);
            _contexto.SaveChanges();
            rs.Mensaje = "El auto ha sido eliminado";
            rs.Success = true;
            return rs;
        }
        public Auto Buscar(string matricula)
        {
            return _contexto.Autos.Find(matricula);
        }
        
    }
}
