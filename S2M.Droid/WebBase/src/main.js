// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
require("babel-es6-polyfill");
import Vue from 'vue'
import Vuetify from 'vuetify'
import ('./main.styl')
import HamburgerApp from './HamburgerApp.vue'
import ListApp from './ListApp.vue'
//import router from './router'


Vue.config.productionTip = false;
Vue.use(Vuetify);

if(GlobalConfigs.navigationType===ProjectConsts.allNavigationTypes.listMenu){
  new Vue({
    el: '#apploc',
    components: { ListApp },
    template: '<ListApp/>'
  });
}
else if(GlobalConfigs.navigationType===ProjectConsts.allNavigationTypes.hamburger){

  new Vue({
    el: '#apploc',
    components: { HamburgerApp },
    template: '<HamburgerApp/>'
  });
}
else if(GlobalConfigs.navigationType===ProjectConsts.allNavigationTypes.singlePage){
  if(GlobalConfigs.useIFramesEverywhere) {
    document.getElementById("apploc").innerHTML = "<iframe\n" +
      "        id=\"my-content\"\n" +
      "        style=\"overflow-y: scroll;position: fixed; width:100%;right:0\"\n" +
      "        width=\"100%\" height=\"100%\" frameborder=\"0\"\n" +
      "        src=\"" + GlobalConfigs.homeSitePageUrl + "\">\n" +
      "      </iframe>";
  }
  else{
    window.location.href=GlobalConfigs.homeSitePageUrl;
  }
}
else{
  document.getElementById("apploc").innerHTML="<h1>Navigation type not found</h1>"
}


document.title=GlobalConfigs.pageTitle;



