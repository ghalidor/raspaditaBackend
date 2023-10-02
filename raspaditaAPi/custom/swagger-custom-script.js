(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            //var logo = document.getElementsByClassName('title');
            //logo[0].href = "https://raspadita.pe/";
            //logo[0].target = "_blank";

            //logo[0].children[0].alt = "Sistemas";
            //logo[0].children[0].src = "https://www.pngmart.com/files/5/Games-PNG-File.png";
            //logo[0].children[0].after(" ApiRaspadita");

            var link = document.querySelector("link[rel*='icon']") || document.createElement('link');;
            document.head.removeChild(link);
            link = document.querySelector("link[rel*='icon']") || document.createElement('link');
            document.head.removeChild(link);
            link = document.createElement('link');
            link.type = 'image/x-icon';
            link.rel = 'shortcut icon';
            link.href = '../custom/lock.png';
            document.getElementsByTagName('head')[0].appendChild(link);

            var elemento = document.getElementsByClassName('title');
            console.log(elemento)
            var imgLogo = document.createElement("img");
            imgLogo.setAttribute('src', 'https://www.pngmart.com/files/5/Games-PNG-File.png');
            elemento.appendChild(imgLogo);

        });
    });

})();

