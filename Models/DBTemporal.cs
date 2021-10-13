using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace EntidadesSistema
{
    public class DBTemporal
    {
        const string pathCarpeta = @"C:\TP03";
        const string pathCadetesTmp = @"C:\TP03\tmp\_dB.cadetes.tmp.txt";
        const string pathPedidosTmp = @"C:\TP03\tmp\_dB.pedidos.tmp.txt";
        const string pathPedidos = @"C:\TP03\_dB.pedidos.txt";
        const string pathCadetes = @"C:\TP03\_dB.cadetes.txt";

        public DBTemporal(){}
        //----------------------------Cadete-------------------------------------------------------//
        public void SaveCadete(int _Dni, string _Nombre, string _Direccion, string _Telefono)
        {
            int idNuevo = ReadCadetesAlmacenados().Count() + 1;
            Cadete nuevoCadete = new Cadete(idNuevo, _Dni, _Nombre, _Direccion, _Telefono);
            SaveCadeteArchivo(nuevoCadete);
        }

        private void SaveCadeteArchivo(Cadete _Cadete)
        {
            string streamJson = JsonSerializer.Serialize(_Cadete);
            try
            {
                using (StreamWriter strWriter = File.AppendText(pathCadetes))
                {
                    strWriter.WriteLine(streamJson);
                    strWriter.Close();
                    strWriter.Dispose();
                }
            }
            catch(FileNotFoundException)
            {
                Directory.CreateDirectory(pathCarpeta);
                StreamWriter archivo = File.CreateText(pathCadetes);
                archivo.Close();
                archivo.Dispose();
            }
        }
        public List<Cadete> ReadCadetesAlmacenados()
        {
            List<Cadete> listaCadetesAlmacenados = new List<Cadete>();
            string lineaAuxiliar = "";
            try
            {
                using (StreamReader strReader = File.OpenText(pathCadetes))
                {
                    while ((lineaAuxiliar = strReader.ReadLine()) != null)
                    {
                        Cadete cadeteObj = JsonSerializer.Deserialize<Cadete>(lineaAuxiliar);
                        listaCadetesAlmacenados.Add(cadeteObj);
                    }
                    strReader.Close();
                    strReader.Dispose();
                }
            }
            catch(FileNotFoundException)
            {
                Directory.CreateDirectory(pathCarpeta);
                FileStream archivo = File.Create(pathCadetes);
                archivo.Close();
                archivo.Dispose();
            }
            return listaCadetesAlmacenados;
        }
        public void DeleteCadete(int _Id)
        {
            List<Cadete> CadetesAlmacenados = ReadCadetesAlmacenados();
            Cadete cadeteToDelete = CadetesAlmacenados.Find(identificacion => identificacion.Id == _Id);
            CadetesAlmacenados.Remove(cadeteToDelete);

        }

        public Cadete ObtenerUnCadete(int _IdReferencia)
        {
            Cadete cadeteBuscador = new Cadete();
            cadeteBuscador.Id = 99999;
            string streamLinea = "";
            try
            {
                using(StreamReader strReader = File.OpenText(pathCadetes))
                {
                    while((streamLinea = strReader.ReadLine()) != null && (cadeteBuscador.Id != _IdReferencia))
                    {
                        cadeteBuscador = JsonSerializer.Deserialize<Cadete>(streamLinea);
                    }
                }
                return cadeteBuscador;
            }
            catch(FileNotFoundException)
            {
                cadeteBuscador.Direccion = "Error";
                cadeteBuscador.CantidadEntregasRealizadas = 0;
                cadeteBuscador.Dni = 99999;
                return cadeteBuscador;
            }
        }
        public void ModifyArchivoCadete(List<Cadete> _ListaCadetes)
        {
            StreamWriter archivo = File.CreateText(pathCadetesTmp);
            archivo.Close();
            foreach(Cadete cadete in _ListaCadetes)
            {
                string streamJson = JsonSerializer.Serialize(cadete);
                using(StreamWriter streamWriter = File.AppendText(pathCadetesTmp))
                {
                    streamWriter.WriteLine(streamJson);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            File.Delete(pathCadetes);
            File.Move(pathCadetesTmp, pathCadetes);
        }
        //----------------------------Pedido-------------------------------------------------------//

        public void AddPedido(int _Numero, string _Observacion, Estado _Estado, string _Dni, string _Nombre, string _Direccion, string _Telefono)
        {
            Pedido pedido = new Pedido(_Numero, _Observacion, _Estado, _Dni, _Nombre, _Direccion, _Telefono);
            AddArchivoPedido(pedido);
        }

        public void AddArchivoPedido(Pedido _Pedido)
        {
            string streamJson = JsonSerializer.Serialize(_Pedido);
            try
            {
                using (StreamWriter strWriter = File.AppendText(pathPedidos))
                {
                    strWriter.WriteLine(streamJson);
                    strWriter.Close();
                    strWriter.Dispose();
                }
            }
            catch(FileNotFoundException)
            {
                StreamWriter archivo = File.CreateText(pathPedidos);
                archivo.Close();
                archivo.Dispose();
                AddArchivoPedido(_Pedido);
            }
        }
        public List<Pedido> ReadPedidosAlmacenados()
        {
            List<Pedido> listaPedidosAlmacenados = new List<Pedido>();
            string lineaAuxiliar = "";
            try
            {
                using (StreamReader strReader = File.OpenText(pathPedidos))
                {
                    while ((lineaAuxiliar = strReader.ReadLine()) != null)
                    {
                        Pedido pedidoObj = JsonSerializer.Deserialize<Pedido>(lineaAuxiliar);
                        listaPedidosAlmacenados.Add(pedidoObj);
                    }
                    strReader.Close();
                    strReader.Dispose();
                }
            }
            catch (FileNotFoundException)
            {
                Directory.CreateDirectory(pathCarpeta);
                FileStream archivo = File.Create(pathPedidos);
                archivo.Close();
                archivo.Dispose();
            }
            return listaPedidosAlmacenados;
        }

        public void ModifyArchivoPedido(List<Pedido> _Pedidos)
        {
            StreamWriter archivo = File.CreateText(pathPedidosTmp);
            archivo.Close();
            foreach (Pedido pedido in _Pedidos)
            {
                string streamJson = JsonSerializer.Serialize(pedido);
                using (StreamWriter streamWriter = File.AppendText(pathPedidosTmp))
                {
                    streamWriter.WriteLine(streamJson);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            File.Delete(pathPedidos);
            File.Move(pathPedidosTmp, pathPedidos);
        }
    }
}
