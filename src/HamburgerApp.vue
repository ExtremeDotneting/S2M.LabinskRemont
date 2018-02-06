<template>
  <v-app id="inspire" :dark="isDarkTheme">
    <v-navigation-drawer
      fixed
      app
      v-model="drawer"
      clipped
    >

      <v-list>
        <template v-for="item in menuItems">
          <v-list-group v-if="item.children" v-model="item.model" no-action>
            <v-list-tile slot="item" @click="onMenuItemClick(item.url)">
              <v-list-tile-action>
                <v-icon>{{ item.model ? item.icon : item.iconAlt }}</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  {{ item.text }}
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile
              v-for="child in item.children"
              @click="onMenuItemClick(item.url)"
            >

              <v-list-tile-action>
                <v-icon v-if="child.icon">{{ child.icon }}</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  {{ child.text }}
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
          </v-list-group>

          <v-list-tile v-else @click="onMenuItemClick(item.url)">
            <v-list-tile-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-tile-action>
            <v-list-tile-content>
              <v-list-tile-title>
                {{ item.text }}
              </v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </template>
      </v-list>

    </v-navigation-drawer>


    <v-toolbar
      :color="menuColor"
      app
      clipped-left
      fixed
      :flat="isMenuFlat"
      dense
      dark
    >

      <!-- Left buttons-->
      <v-toolbar-title :style="$vuetify.breakpoint.smAndUp ? 'width: 300px; min-width: 290px' : 'min-width: 72px'"
                       class="ml-0">
        <v-toolbar-side-icon id="my-toolbaricon" @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-xs-only">{{appTitle}}</span>
      </v-toolbar-title>

      <!-- Right buttons-->
      <div class="d-flex align-center" style="margin-left: auto; ">
        <!--<v-btn icon>-->
          <!--<v-icon>apps</v-icon>-->
        <!--</v-btn>-->
        <!--<v-btn icon>-->
          <!--<v-icon>notifications</v-icon>-->
        <!--</v-btn>-->
        <!--<v-btn icon>-->
          <v-avatar size="22px" tile v-if="showLogo">
            <img
              src="./assets/logo.png"
              alt=""
            >
          </v-avatar>
        <!--</v-btn>-->
      </div>

    </v-toolbar>

    <v-content id="my-div-content">
      <iframe
        id="my-content"
        style="background: #FFFFFF;overflow-y: scroll;position: fixed; width:100%;right:0"
        width="100%" height="100%" frameborder="0"
        :src="siteUrl">
      </iframe>
      <!--<div id="my-content">-->

      <!--<v-container fluid fill-height>-->
      <!--<v-layout justify-center align-top>-->
      <!--<v-flex>-->
      <!--<iframe-->
      <!--style="overflow-y: scroll;position: fixed; width:100%;right:0"-->
      <!--width="100%" height="100%" frameborder="0"-->
      <!--src="//field-rage.ru" >-->

      <!--</v-flex>-->
      <!--</v-layout>-->

      <!--</v-container>-->

      <!--</div>-->
    </v-content>

  </v-app>
</template>

<script>


  var calcSizeGlobal = null;

  export default {


    name: 'HamburgerApp',
    data: () => ({
      dialog: false,
      drawer: null,
      siteUrl:GlobalConfigs.homeSitePageUrl,
      menuItems:GlobalConfigs.menuItems,
      isDarkTheme:GlobalConfigs.styling.isDarkTheme,
      menuColor:GlobalConfigs.styling.menuColor,
      showLogo:GlobalConfigs.styling.showLogo,
      isMenuFlat:GlobalConfigs.styling.isMenuFlat
    }),
    methods:{
      onMenuItemClick:function (url) {
        if(GlobalConfigs.useIFramesEverywhere) {
          this.siteUrl = url;
        }
        else{
          window.location.href=url;
        }
      }
    },
    watch: {
      drawer: (val) => {
        if (this.myContentDiv === undefined) {
          this.myContentDiv = document.getElementById("my-content");
        }
        var myD = this.myContentDiv;
        if (window.innerWidth > 1264 && val) {
          myD.style.width = "calc(100% - 300px)";
        }
        else {
          myD.style.width = "100%";
        }
      }
    },
    computed:{
      appTitle:{
        get:function(){
          return GlobalConfigs.styling.showTitleInMenu ? GlobalConfigs.pageTitle : "";
        }
      }
    },
    props: {
      source: Object
    },

    //hooks!
    created: function () {
//            for (var i = 0; i < 50; i++) {
//                this.$data.content.push({label: 'label#' + i});
//            }
    },
    mounted: function () {
      function initCalcSizeGlobal() {
        var divContent = null, content = null;
        divContent = document.getElementById("my-div-content").children[0];
        content = document.getElementById("my-content");

        function calcSize() {

          content.style.height = "calc(100% - " + divContent.style.paddingTop + ")";
        }

        calcSizeGlobal = calcSize;

      };
      initCalcSizeGlobal();
      calcSizeGlobal();
      window.addEventListener('resize', calcSizeGlobal);
    },
    destroyed: function () {
      window.attachEvent('resize', calcSizeGlobal);
    }
    //!hooks

  }
</script>

<style>

</style>
