const GlobalConfigs = {
  pageTitle:"Натяжные потолки",
  navigationType:ProjectConsts.allNavigationTypes.hamburger,  //can be "hamburger", "single_page"...
  useIFramesEverywhere:true,
  homeSitePageUrl:"http://labinsk-remont.ru",
  menuItems:[
    {icon: 'home', text: 'Главная', url:"http://labinsk-remont.ru"},
    {icon: 'list', text: 'Новости', 
	  url:"https://zen.yandex.ru/id/59711cf73c50f7cc7f69b50c", notLoadToIFrame:true},
    {icon: 'photo', text: 'Фото', 
	  url:"http://labinsk-remont.ru/%D0%A4%D0%BE%D1%82%D0%BE/"},
	{icon: 'info', text: 'О нас', 
	  url:"http://labinsk-remont.ru/%D0%9E-%D0%BD%D0%B0%D1%81/"},
    {icon: 'mail', text: 'Задать вопрос', 
	  url:"http://labinsk-remont.ru/%D0%9A%D0%BE%D0%BD%D1%82%D0%B0%D0%BA%D1%82%D1%8B/"},
	{icon: 'group', text: 'О разработчике', url:""}
  ],
  styling:{
    isDarkTheme:0,
    menuColor:"deep-purple darken-2", //from https://vuetifyjs.com/style/colors
    showLogo:false,
    showTitleInMenu:true,
    isMenuFlat:false
  }
}



