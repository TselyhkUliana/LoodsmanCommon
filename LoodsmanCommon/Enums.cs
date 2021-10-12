﻿namespace LoodsmanCommon
{
    /// <summary>
    /// Режим возврата списка атрибутов 
    /// </summary>
    public enum GetInfoAboutTypeMode
    {
        /// <summary>
        /// Возвращает список возможных атрибутов типа.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_ID] int – уникальный идентификатор значения атрибута;
        ///<br/>[_NAME] string – название атрибута;
        ///<br/>[_ATTRTYPE] int – тип атрибута;
        ///<br/>[_DEFAULT] string – значение по умолчанию;
        ///<br/>[_LIST] text – список возможных значений;
        ///<br/>[_ACCESSLEVEL] int –  уровень прав доступа (1 – Только чтение, 2 – Чтение/запись). Начиная с версии ЛОЦМАН:PLM 2017 поле устарело и его значение всегда равно 2;
        ///<br/>[_ONLYLISTITEMS] int – атрибут может принимать значения только из списка (0 - Любое, 1 - Из списка);
        ///<br/>[_SYSTEM] int – признак того, что атрибут является служебным, всегда равен 0;
        ///<br/>[_OBLIGATORY] int – признак «Обязательный» (0 – необязательный, 1 – обязательный).
        /// </summary>
        Mode1 = 1,
        /// <summary>
        /// Возвращает список возможных состояний типа без учета доступа к типу и состоянию.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_NAME] string – название состояния;
        ///<br/>[_VERSIONING] int – зарезервировано.
        /// </summary>
        Mode2 = 2,
        /// <summary>
        /// Возвращает список возможных состояний типа с учетом доступа к типу и его состояниям.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_NAME] string – название состояния.
        /// </summary>
        Mode3 = 3,
        /// <summary>
        /// Возвращает все типы, с которыми может быть связан объект заданного типа любыми видами связей и в любом направлении.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_NAME] string – название типа;
        ///<br/>[_ID_LINKTYPE] int – идентификатор типа связи;
        ///<br/>[_LINKTYPE] string – тип связи;
        ///<br/>[_INVERSENAME] string – обратное название типа связи;
        ///<br/>[_LINKICON] image – картинка для типа связи;
        ///<br/>[_LINKORDER] int – порядок следования;
        ///<br/>[_LINKKIND] int – вид связи (1 – горизонтальная, 0 – вертикальная);
        ///<br/>[_DIRECTION] int – направление, может быть связан c типом:
        ///<br/>-1 – только в обратном направлении;
        ///<br/>1 – только в прямом направлении;
        ///<br/>0 – в прямом и обратном направлении;
        ///<br/>[_CANCREATE] int – признак существования привилегии для создания объекта:
        ///<br/>1 – создание объекта возможно;
        ///<br/>0 – создание объекта запрещено;
        ///<br/>[_IS_QUANTITY] int – признак количественной связи:
        ///<br/>0 – в любом направлении связь неколичественная;
        ///<br/>1 – если возвращенный тип выступает в роли вышестоящего для заданного типа;
        ///<br/>2 – если возвращенный тип выступает в роли нижестоящего для заданного типа;
        ///<br/>3 – в любом направлении связь количественная.
        /// </summary>
        Mode4 = 4,
        /// <summary>
        /// Возвращает название инструмента, в котором редактируется документ данного типа. Если инструмент не сопоставлен, то возвратится пустой набор данных.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_TOOLNAME] string – название инструмента;
        ///<br/>[_EXTENSION] string – расширение файла, который редактируется в соответствующем инструменте.
        /// </summary>
        Mode6 = 6,
        /// <summary>
        /// Возвращает список карточек для типа в соответствии с привязкой карточки к ролям, назначенным данному пользователю.
        ///<br/>Если на вход подано stTypeName – заведомо несуществующее, то на выходе придут все карточки для пользователя.
        ///<br/>Если карточка не привязана ни к одной роли, то на выходе ее не будет.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_ID] int – идентификатор карточки;
        ///<br/>[_NAME] string – название карточки;
        ///<br/>[_TYPE] string – название типа, которому сопоставлена карточка.
        /// </summary>
        Mode7 = 7,
        /// <summary>
        /// Возвращает список типов, с которыми объект указанного типа может быть связан вертикальными связями.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_ID] int – уникальный идентификатор типа;
        ///<br/>[_NAME] string – название типа;
        ///<br/>[_ICON] image – значок типа;
        ///<br/>[_ATTRNAME] string – название ключевого атрибута типа;
        ///<br/>[_LINKTYPE] string – название типа связи.
        /// </summary>
        Mode8 = 8,
        /// <summary>
        /// Возвращает список используемых классов типа.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_NAME] string – класс справочника;
        ///<br/>[_PRODUCTSOURCE] string – правило формирования ключевого атрибута для объектов класса;
        ///<br/>[_STATESOURCE] string – условие назначения состояния для объектов класса;
        ///<br/>[_CLASS_ID] int – идентификатор класса справочника;
        ///<br/>[_CAPTION] string – название класса справочника;
        ///<br/>[_NODE] string – идентификатор узла справочника класса.
        /// </summary>
        Mode9 = 9,
        /// <summary>
        /// Возвращает внешние атрибуты типа.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_NAME] string – название атрибута;
        ///<br/>[_OBJECTATTRIBUTENAME] string – Начиная с версии ЛОЦМАН:PLM 2018.1 поле устарело и его значение всегда равно 'Deprecated'.
        /// </summary>
        Mode10 = 10,
        /// <summary>
        /// Возвращает список связей, в которых может состоять объект данного типа.
        ///<br/>Если на вход подано stTypeName, заведомо несуществующее, на выходе будут данные для всех типов системы.
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_TYPE] string – название типа (повторяет то, что пришло на входе);
        ///<br/>[_NAME] string – название типа связи;
        ///<br/>[_DIRECTION] int – направление, может быть связан c типом: (-1 – только в обратном направлении, 1 – только в прямом направлении, 0 – в прямом и обратном направлении);
        ///<br/>[_ID_LINKTYPE] int – идентификатор типа связи;
        ///<br/>[_INVERSENAME] string – обратное название типа связи;
        ///<br/>[_LINKICON] image – значок типа связи;
        ///<br/>[_LINKORDER] int – порядок следования;
        ///<br/>[_LINKKIND] int – вид связи (1 – горизонтальная, 0 – вертикальная).
        /// </summary>
        Mode11 = 11,
        /// <summary>
        /// Возвращает список возможных атрибутов типа, включая служебные. (поддерживается в версии ЛОЦМАН:PLM 2012 и более поздних)
        ///<br/>Возвращает набор данных с полями:
        ///<br/>[_ID] int – уникальный идентификатор значения атрибута;
        ///<br/>[_NAME] string – название атрибута;
        ///<br/>[_ATTRTYPE] int – тип атрибута;
        ///<br/>[_DEFAULT] string – значение по умолчанию;
        ///<br/>[_LIST] text – список возможных значений;
        ///<br/>[_ACCESSLEVEL] int –  уровень прав доступа (1 – Только чтение, 2 – Чтение/запись). Начиная с версии ЛОЦМАН:PLM 2017 поле устарело и его значение всегда равно 2;
        ///<br/>[_ONLYLISTITEMS] int – атрибут может принимать значения только из списка (0 - Любое, 1 - Из списка);
        ///<br/>[_OBLIGATORY] int – признак «Обязательный» (0 – необязательный, 1 – обязательный);
        ///<br/>[_SYSTEM] int – признак того, что атрибут является служебным (0 – Обычный, 1 – Служебный).
        /// </summary>
        Mode12 = 12,
    }
    /// <summary>
    /// Режим возврата списка атрибутов 
    /// </summary>
    public enum GetAttributeListMode
    {
        /// <summary>
        /// Возвращать все атрибуты (обычные и служебные).
        /// </summary>
        All = 0,
        /// <summary>
        /// Возвращать только обычные атрибуты.
        /// </summary>
        OnlyRegular = 1,
        /// <summary>
        /// Возвращать только служебные атрибуты.
        /// </summary>
        OnlyService = 2
    }

    /// <summary>
    /// Направление связи
    /// </summary>
    public enum LinkDirection
    {
        /// <summary>
        /// Прямая связь
        /// </summary>
        Forward = 1,
        /// <summary>
        /// Обратная связь
        /// </summary>
        Backward = -1,
        /// <summary>
        /// Прямая и обратная связь
        /// </summary>
        ForwardAndBackward = 0
    }

    /// <summary>
    /// Режим чекаута
    /// </summary>
    public enum CheckOutMode
    {
        /// <summary>
        /// Блокировать головной объект. По умолчанию.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Блокировать все привязанные объекты с полной разузловкой вниз.
        /// </summary>
        Through = 1
    }

    /// <summary>
    /// Уровни доступа
    /// </summary>
    public enum AccessLevel
    {
        /// <summary>
        /// Нет доступа
        /// </summary>
        No = 0,
        /// <summary>
        /// Чтение
        /// </summary>
        Read = 1,
        /// <summary>
        /// Чтение-запись
        /// </summary>
        Write = 2,
        /// <summary>
        /// Полный доступ
        /// </summary>
        Full = 3
    }

    /// <summary>
    /// Уровни блокировки
    /// </summary>
    public enum LockLevel
    {
        /// <summary>
        /// Не заблокирован
        /// </summary>
        No = 0,
        /// <summary>
        /// Заблокирован текущим пользователем
        /// </summary>
        Self = 1,
        /// <summary>
        /// Заблокирован другим пользователем
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Типы атрибутов
    /// </summary>
    public enum AttributeType : short
    {
        /// <summary>
        /// Строка
        /// </summary>
        String = 0,
        /// <summary>
        /// Целое
        /// </summary>
        Int = 1,
        /// <summary>
        /// Вещественное
        /// </summary>
        Double = 2,
        /// <summary>
        /// Дата
        /// </summary>
        DateTime = 3,
        /// <summary>
        /// Текст
        /// </summary>
        Text = 5,
        /// <summary>
        /// Изображение
        /// </summary>
        Image = 6
    }
}
