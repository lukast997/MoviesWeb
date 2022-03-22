import {Bioskop} from "./Bioskop.js";
import {Projekcija} from "./Projekcija.js"


var listaBioskopa = [];

fetch("https://localhost:5001/Bioskop/SviBioskopi")
.then(p=>{
    p.json().then(bioskopi => {
        bioskopi.forEach( bioskop =>{
            var p = new Bioskop(bioskop.idBioskopa, bioskop.naziv, bioskop.adresa);
            listaBioskopa.push(p);
        });
        var projekcija = new Projekcija(listaBioskopa,);
        projekcija.crtaj(document.body)

    })
})
   


