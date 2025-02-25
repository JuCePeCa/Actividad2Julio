using Microsoft.Identity.Client;
using PersonasAutos.Dtos;
using PersonasAutos.Metodos;
using PersonasAutos.Models;

namespace PersonasAutos.Servicio
{
    public class PersonaService:IMetodosPersona
    {
        private Practica2Context _contexto = new Practica2Context();
        public Respuesta Guardar(Persona persona)
        {
            Respuesta rs = new Respuesta();
            if (_contexto.Personas.Find(persona.Curp) != null)
            {
                rs.Mensaje = "Esta Persona no se registro porque su curp ya existe en la base de datos";
                rs.Success = false;
                rs.obj = persona.Curp;
                return rs;
            }
            foreach (Persona p in _contexto.Personas)
            {
                if (p.Nombre == persona.Nombre && p.Apellido == persona.Apellido)
                {
                    rs.Mensaje = "Esta Persona no se registro porque su nombre y apellido ya existe en la base de datos";
                    rs.Success = false;
                    rs.obj = persona;
                    return rs;
                }
            }
            rs.Mensaje = "Esta Persona ha sido registrada en la base de datos";
            rs.Success = true;
            rs.obj = persona;
            _contexto.Personas.Add(persona);
            _contexto.SaveChanges();
            return rs;
        }
        public Respuesta Editar(Persona persona)
        {
            Respuesta rs = new Respuesta();
            if (Buscar(persona.Curp) == null)
            {
                rs.Mensaje = "La persona que tratas de editar no existe en la base de datos";
                rs.Success = false;
                rs.obj = persona.Curp;
                return rs;
            }
            Persona persona_aux = Buscar(persona.Curp);
            persona_aux.Nombre = persona.Nombre;
            persona_aux.Apellido = persona.Apellido;
            persona_aux.Edad = persona.Edad;
            persona_aux.Genero = persona.Genero;
            persona_aux.Ciudad = persona.Ciudad;
            persona_aux.Telefono = persona.Telefono;
            persona_aux.EstadoCivil = persona.EstadoCivil;
            persona_aux.Estatura = persona.Estatura;
            _contexto.SaveChanges();
            rs.Mensaje = "La persona ha sido editada";
            rs.Success = true;
            rs.obj = persona;
            return rs;
        }
        public Respuesta Eliminar(Persona persona)
        {
            Respuesta rs = new Respuesta();

            if(Buscar(persona.Curp) == null )
            {
                rs.Mensaje = "La persona que tratas de eliminar no existe en la base de datos";
                rs.Success = false;
                rs.obj = persona.Curp;
                return rs;
            }
            
            persona = _contexto.Personas.Find(persona.Curp);
            
            if(persona.Autos.Count() == 0)
            {
                rs.obj = persona;
                _contexto.Personas.Remove(persona);
                _contexto.SaveChanges();
                rs.Mensaje = "La persona ha sido eliminada";
                rs.Success = true;
                return rs;
            }
            rs.Mensaje = "La persona no se puede eliminar porque tiene Autos asignados";
            rs.Success = false;
            rs.obj = persona.Autos;
            return rs;
        }
        public Persona Buscar(string curp)
        {
            return _contexto.Personas.Find(curp);
        }
        public List<Persona> MostrarPersonas()
        {
            return _contexto.Personas.ToList();        }
    }
}
