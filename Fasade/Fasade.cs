using System;

namespace SandBox.Patterns.Fasade
{    
    public class DatabaseFasade: IDisposable
    {
        private DataBase _dataBase;
        private BaseConnecter _baseConnecter;
        
        public DatabaseFasade()
        {
            _dataBase = new DataBase("/Data/");
            _baseConnecter = new BaseConnecter(_dataBase);
        }
        
        public object LoadData()
        {
            if (!_baseConnecter.IsConnected)
            {
                _baseConnecter.Connect();
            }

            return _baseConnecter.Load();
        }
        
        public void SaveData(object data)
        {
            if (!_baseConnecter.IsConnected)
            {
                _baseConnecter.Connect();
            }
            _baseConnecter.Save(data);
        }

        public void Dispose()
        {
            _baseConnecter.Disconnect(); 
        }
    }
    
    public class DataBase
    {
        public DataBase(string path)
        {
            
        }
    }

    public class BaseConnecter
    {
        public bool IsConnected { get; set; }
        public BaseConnecter(DataBase dataBase)
        {
            
        }

        public void Connect()
        {
            IsConnected = true;
        }

        public object Load()
        {
            return null;
        }
        
        public void Save(object data)
        {
            
        }

        public void Disconnect()
        {
            IsConnected = false;
        }
        
    }
}