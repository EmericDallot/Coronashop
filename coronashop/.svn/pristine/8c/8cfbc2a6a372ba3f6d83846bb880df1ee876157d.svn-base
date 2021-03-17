using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    /// <summary>
    /// Classe définissant la classe Parameter
    /// </summary>
    [Serializable]
    public class Parameter : INotifyPropertyChanged
    {
        /// <summary>
        /// _Value de ce Parameter
        /// </summary>
        [NonSerialized]
        private int _Value;
        /// <summary>
        /// Value de ce Parameter
        /// </summary>
        public int Value
        {
            get { return _Value; }
            set { _Value = value; OnPropertyChanged(nameof(Value)); }
        }
        /// <summary>
        /// PropertyChanged de ce Parameter
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="value">Value de ce Parameter</param>
        public Parameter(int value)
        {
            Value = value;
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="name">Nom de l'attribut</param>
        protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



    }
}
