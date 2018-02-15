<template>
  <v-app id="inspire" :dark="isDarkTheme">
    <v-toolbar
      :color="menuColor"
      app
      clipped-left
      fixed
      dense
      :flat="isMenuFlat"
      dark
    >

      <!-- Left buttons-->
      <v-toolbar-title :style="$vuetify.breakpoint.smAndUp ? 'width: 300px; min-width: 290px' : 'min-width: 72px'"
                       class="ml-4">
        <span>{{appTitle}}</span>
      </v-toolbar-title>

      <!-- Right buttons-->
      <div class="d-flex align-center" style="margin-left: auto; ">
        <v-avatar size="22px" tile v-if="showLogo">
          <img
            src="./assets/logo.png"
            alt=""
          >
        </v-avatar>
      </div>

    </v-toolbar>

    <v-content id="my-div-content">
        <v-list id="my-content" style="position: absolute; height: 100%; width: 100%;">
          <template v-for="item in menuItems">
            <v-list-tile @click="onMenuItemClick(item.url)">
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
    </v-content>


  </v-app>
</template>


<script>


  var calcSizeGlobal = null;

  export default {
    name: 'ListApp',
    data: () => ({
      dialog: false,
      drawer: 1,
      menuItems: GlobalConfigs.menuItems,
      isDarkTheme: GlobalConfigs.styling.isDarkTheme,
      menuColor: GlobalConfigs.styling.menuColor,
      showLogo: GlobalConfigs.styling.showLogo,
      isMenuFlat: GlobalConfigs.styling.isMenuFlat
    }),
    methods: {
      onMenuItemClick: function (url) {
        if (GlobalConfigs.useIFramesEverywhere) {
          alert("Disable iframes to make it work!")
        }
        else {
          window.location.href = url;
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
    computed: {
      appTitle: {
        get: function () {
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
