﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter
{
    public static class Constants
    {
        public const string RulesNotUpload = "Файл с заменами наименований препаратов не загружен или не содержит записей. Файлы будут конвертированы без замены наименований препаратов.";
        public const string FolderForSavingIsnotChoosen = "Не выбрана папка для сохранения файлов. Выберите папку для сохранения результатов конвертации.";
        public const string UpakovkiCellIsEmpty = "Кол-во упаковок не указано. Пустая ячейка.";
        public const string IncorrectRegionName = "Некорректное название области.";
        public const string IncorrectNameAndAdress = "Ячейка клиент с адресом пустая.";
        public const string IncorrectDate = "Выбранная дата больше сегодня";
        public const string IncorrectItemName = "Не указано название препарата";
        public const string IncorrectAdressSklada = "Адрес склада содержит только название дистрибьютора";
    }
}
