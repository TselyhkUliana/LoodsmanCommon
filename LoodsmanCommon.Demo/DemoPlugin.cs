﻿using Ascon.Plm.Loodsman.PluginSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoodsmanCommon.Demo
{
    [LoodsmanPlugin]
    public class DemoPlugin : LoodsmanWPFPluginBase
    {
        public override void BindMenu(IMenuDefinition menu)
        {
            menu.AddMenuItem("Тест демо#В работу(SelectedObjectCheckOut), удалить, отказ", Command1, CheckCommand);
            menu.AddMenuItem("Тест демо#В работу(Empty CheckOut AddToCheckOut), удалить, отказ", Command2, CheckCommand);
            menu.AddMenuItem("Тест демо#В работу(No empty ChekOut), удалить, отказ", Command3, CheckCommand);
        }

        protected override bool CheckCommand(INetPluginCall iNetPC)
        {
            if (_proxy is null && iNetPC != null) //метод OnConnectToDb не срабатывает при первом добавлении команды на панель инструментов.
                PluginInit(iNetPC);

            return base.CheckCommand(iNetPC);
        }

        private void Command1(INetPluginCall iNetPC)
        {
            try
            {
                _proxy.InitNetPluginCall(iNetPC);
                _proxy.SelectedObjectCheckOut();
                _proxy.KillVersion(_proxy.SelectedObject.Id);
                _proxy.CancelCheckOut();
            }
            catch (Exception ex)
            {
                _proxy.CancelCheckOut();
                MessageBox.Show(ex.Message);
            }
        }

        private void Command2(INetPluginCall iNetPC)
        {
            try
            {
                _proxy.InitNetPluginCall(iNetPC);
                _proxy.CheckOut();
                _proxy.ConnectToCheckOut();
                var testObjectId = 1012;
                _proxy.AddToCheckOut(testObjectId);
                _proxy.KillVersion(testObjectId);
                _proxy.CancelCheckOut();
            }
            catch (Exception ex)
            {
                _proxy.CancelCheckOut();
                MessageBox.Show(ex.Message);
            }
        }

        private void Command3(INetPluginCall iNetPC)
        {
            try
            {
                _proxy.InitNetPluginCall(iNetPC);
                _proxy.CheckOut("Сборочная единица", "АГ52.289.047", "2");
                _proxy.ConnectToCheckOut();
                var testObjectId = 1012;
                _proxy.KillVersion(testObjectId);
                _proxy.CancelCheckOut();
            }
            catch (Exception ex)
            {
                _proxy.CancelCheckOut();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
