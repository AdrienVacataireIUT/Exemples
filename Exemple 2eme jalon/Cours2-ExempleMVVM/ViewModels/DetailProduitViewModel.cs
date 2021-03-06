﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cours2_ExempleMVVM.Mock;
using Cours2_ExempleMVVM.ViewModels.Common;

namespace Cours2_ExempleMVVM.ViewModels
{
    /// <summary>
    /// ViewModel représentant un Produit (avec son détail)
    /// Hérite de BaseViewModel
    /// </summary>
    public class DetailProduitViewModel : BaseViewModel
    {
        #region Variables

        private string _code;
        private string _nom;
        private RelayCommand _addOperation;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="p">Produit à transformer en DetailProduitViewModel</param>
        /// </summary>
        public DetailProduitViewModel(Produit p)
        {
            _code = p.Code;
            _nom = p.Nom;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Code du produit
        /// </summary>
        public string Code 
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Nom du produit
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand AddOperation
        {
            get
            {
                if (_addOperation == null)
                    _addOperation = new RelayCommand(() => this.ShowWindowOperation());
                return _addOperation;
            }
        }

        /// <summary>
        /// Permet l'ouverture de la fenêtre
        /// </summary>
        private void ShowWindowOperation()
        {
            Views.Operation operationWindow = new Views.Operation();
            operationWindow.DataContext = this;
            operationWindow.ShowDialog();
        }

        #endregion
    }
}
