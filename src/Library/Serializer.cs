using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresas es el experto en conocer a las empresas, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresas y/o remover Empresas.
    /// </summary>
    public class Serializer : IJsonConvertible
    {
        [JsonInclude]
        public List<Empresa> Empresas { get; set; }
        [JsonInclude]
        public List<Administrador> Administradores { get; set; }
        [JsonInclude]
        public List<IUsuario> Emprendedores { get; set; }

        /// <summary>
        /// Constructor para sumarle instancia a la clasica.
        /// </summary>
        
        [JsonConstructor]
        public Serializer()
        {
            this.Emprendedores = ListaUsuarios.GetInstance().Usuarios;
            this.Empresas = ListaEmpresas.GetInstance().Empresas;
            this.Administradores = ListaAdministradores.GetInstance().Administradores;
        }

        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }

        public void LoadFromJson(string json)
        {
            //var options = new JsonSerializerOptions();
            //options.Converters.Add(new JsonStringEnumConverter());

            Serializer serializer = JsonSerializer.Deserialize<Serializer>(json);
            this.Empresas = serializer.Empresas;
            ListaEmpresas.GetInstance().Empresas.AddRange(serializer.Empresas);

            this.Administradores = serializer.Administradores;
            ListaAdministradores.GetInstance().Administradores.AddRange(serializer.Administradores);

            this.Emprendedores = serializer.Emprendedores;
            ListaUsuarios.GetInstance().Usuarios.AddRange(serializer.Emprendedores);
        }
    }
}