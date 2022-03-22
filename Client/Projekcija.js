import { Bioskop } from "./Bioskop.js";
import { Dani } from "./Dani.js";
export class Projekcija{
    constructor(listaBioskopa){
        this.listaBioskopa = listaBioskopa;
        this.kont = null;
    }   
    crtaj(host){
        this.kont = document.createElement("div");
        this.kont.className = "projekcijaKontejner";
        host.appendChild(this.kont);

        let kontForma = document.createElement("div");
        kontForma.className = "forma";
        this.kont.appendChild(kontForma);

        this.crtajFormu(kontForma);
    }
    crtajFormu(host){
        let d = document.createElement('div');
        d.className = "selectMovie";
        
        let l = document.createElement('h2');
        l.className = "naslov";
        l.innerHTML= "U koji bioskop zelite da idete";
        d.appendChild(l);

        let se = document.createElement("select");
        se.className = "bioskopi";
        d.appendChild(se);

        let op;
        this.listaBioskopa.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p.naziv;
            op.value = p.id;
            se.appendChild(op);
        })
        let btn;
        btn = document.createElement("button");
        btn.innerHTML= "Odaberi bioskop";
        btn.className = "odaberiBioskop";
        btn.onclick=(ev)=>this.nadjiRepertoar(host);
        d.appendChild(btn);
        let div;
        let dodajBtn;
        let izmeniB;
        let izmeniBtn;
        let izmeniD;
        let dodajD;
        let dodajDD;
        let dodajB;
        let izbrisiD;
        let izbrisiBtn;
        div = document.createElement("div");
        div.className = "pretragaKontejner";
        dodajD = document.createElement("div");
        dodajD.className = "dodajBioskop";
        dodajDD = document.createElement("div");
        dodajDD.className = "dodajDiv";
        dodajBtn = document.createElement("button");
        dodajBtn.onclick=(ev)=>this.DodajBioskop();
        dodajBtn.innerHTML = "Dodaj Bioskop";
        dodajB = document.createElement("input");
        dodajB.placeholder = "Unesite naziv";
        dodajB.id = "dodajBioskop";
        dodajB.type= "text";
        dodajDD.appendChild(dodajB);
        dodajDD.appendChild(dodajBtn);
        dodajD.appendChild(dodajDD);
        let izs = document.createElement("select");
        izs.className = "bioskopiI";
        let iz;
        this.listaBioskopa.forEach(p=>{
            iz = document.createElement("option");
            iz.innerHTML = p.naziv;
            iz.value = p.id;
            izs.appendChild(iz);
        })
        izmeniD = document.createElement("div");
        izmeniB = document.createElement("input");
        izmeniB.placeholder = "Naziv Bioskopa";
        izmeniB.type = "text";
        izmeniB.id = "izmeniB";
        izmeniBtn = document.createElement("button");
        izmeniBtn.innerHTML ="Izmeni";
        izmeniBtn.onclick=(ev)=>this.IzmeniBioskop();
        izmeniD.appendChild(izs);
        izmeniD.appendChild(izmeniB);
        izmeniD.appendChild(izmeniBtn);
        dodajD.appendChild(izmeniD);
        izbrisiD = document.createElement("div");
        izbrisiD.className = "dodajDiv";

        let izbb = document.createElement("select");
        izbb.className = "bioskopiIzb";
        let izb;
        this.listaBioskopa.forEach(p=>{
            izb = document.createElement("option");
            izb.innerHTML = p.naziv;
            izb.value = p.id;
            izbb.appendChild(izb);
        })

        izbrisiBtn = document.createElement("button");
        izbrisiBtn.innerHTML ="Izbrisi";
        izbrisiD.appendChild(izbb);
        izbrisiBtn.onclick=(ev)=>this.IzbrisiBioskop();
        izbrisiD.appendChild(izbrisiBtn);
        dodajD.appendChild(izbrisiD);
        let sr;
        sr = document.createElement("input");
        sr.type="text";
        sr.placeholder = "Pronadji Film";
        sr.classList = "pronadji";
        sr.id = "pronadji";
        let sbtn = document.createElement("button");
        sbtn.className = "pronadjibtn";
        sbtn.innerHTML = "pronadji";
        sbtn.onclick=(ev)=>this.pronadjiFilm(host);
        host.appendChild(d);
        host.appendChild(dodajD);
        div.appendChild(sr);
        div.appendChild(sbtn)
        host.appendChild(div)
    }

    nadjiRepertoar(id, host){
        let optionEl = this.kont.querySelector("select");
        var bioskopId = optionEl.options[optionEl.selectedIndex].value;
        var listaDana = [];
        if(document.getElementById("kontejnerDana")){
            document.getElementById("kontejnerDana").remove()
        }
        if(document.getElementById("kontejnerFilma")){
            document.getElementById("kontejnerFilma").remove()
        }
        fetch("https://localhost:5001/Bioskop/BioskopiPoDanima?index="+bioskopId)
        .then(p =>{
            p.json().then(dan =>{
                dan[0].daniBioskop.forEach( p =>{
                    var d = new Dani(p.idDana, p.naziv);
                    listaDana.push(d);
                })
                
            let kontD;
            kontD = document.createElement("div");
            kontD.id = "kontejnerDana";
            if(listaDana.length === 0){
                alert("Bioskop trenutno ne radi")
            }
            listaDana.forEach( p => {
                let btn;
                btn = document.createElement("button");
                btn.innerHTML= p.naziv;
                btn.value = p.id;
                btn.onclick=(ev)=>this.crtajReperoar(p.id);
                kontD.appendChild(btn);
            })
            this.kont.appendChild(kontD);
            })
        })
        
    }
    crtajReperoar(id){
        var filmKont;
        if(document.getElementById("kontejnerFilma")){
            document.getElementById("kontejnerFilma").remove()
        }
        filmKont = document.createElement("div")
        filmKont.id = "kontejnerFilma"
        fetch("https://localhost:5001/Dani/DaniFilm?id="+id)
        .then(p =>{
            p.json().then( film =>{
                film[0].filmoviDani.forEach( f => {
                    var filmItm;
                    filmItm = document.createElement("div");
                    filmItm.className="filmItem";
                    var naslov;
                    naslov = document.createElement("p");
                    naslov.className = "filmNaslov";
                    naslov.innerHTML = "Naziv: "+f.naziv;
                    filmItm.appendChild(naslov);
                    var cena
                    cena = document.createElement("p");
                    cena.className = "filmCena";
                    cena.innerHTML = "cena: "+f.cena;
                    filmItm.appendChild(cena);
                    var projekcija;
                    projekcija = document.createElement("p");
                    projekcija.className="filmprojekcija";
                    projekcija.innerHTML = "Pocinje u: "+f.projekcija
                    filmItm.appendChild(projekcija)
                    filmKont.appendChild(filmItm)
                })
            })
            this.kont.appendChild(filmKont)
        });
    }

    pronadjiFilm(){
        let film = document.getElementById("pronadji").value;
        var filmKont;
        if(document.getElementById("kontejnerFilma")){
            document.getElementById("kontejnerFilma").remove()
        }
        filmKont = document.createElement("div")
        filmKont.id = "kontejnerFilma"
        fetch("https://localhost:5001/Film/FilmoviPoImenu?naziv="+film)
        .then(p =>{
            p.json().then( f =>{
                if(f.length != 0)
                {
                    let d = document.createElement('div');
                    d.className = "pretragaFilma";
                    var filmItm;
                    filmItm = document.createElement("div");
                    filmItm.className="filmItem";
                    var naslov;
                    naslov = document.createElement("p");
                    naslov.className = "filmNaslov";
                    naslov.innerHTML = "Naziv: "+f[0].naziv;
                    filmItm.appendChild(naslov);
                    var cena
                    cena = document.createElement("p");
                    cena.className = "filmCena";
                    cena.innerHTML = "cena: "+f[0].cena;
                    filmItm.appendChild(cena);
                    var projekcija;
                    projekcija = document.createElement("p");
                    projekcija.className="filmprojekcija";
                    projekcija.innerHTML = "Pocinje u: "+f[0].projekcija;
                    filmItm.appendChild(projekcija);
                    filmKont.appendChild(filmItm);
                }
                else{
                    alert("Trazeni film nije ni u jednom bioskopu");
                }
                
                
                this.kont.appendChild(filmKont)
            })
            
        })
    }
    DodajBioskop(){
        let bioskop = document.getElementById("dodajBioskop").value;
        if(bioskop){
            let bioskop1 = {
                "naziv":bioskop,
                "adresa": "adresa"}
            fetch("https://localhost:5001/Bioskop/Dodaj Bioskop",{
                method:"POST",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(bioskop1)
            }).then( b => {
                alert("Dodali ste bioskop");
            })
        }
        else{
            alert("Unesite naziv bioskopa");
        }
    }
    IzmeniBioskop(){
        let bioskop = document.getElementById("izmeniB").value;
        if(bioskop){
        let bioskop1 = {
            "naziv":bioskop,
            "adresa": "adresa"}
        let optionEl = this.kont.querySelector(".bioskopiI");
        var bioskopId = optionEl.options[optionEl.selectedIndex].value;
        fetch("https://localhost:5001/Bioskop/Izmeni Bioskop?IdBioskopa="+bioskopId,{
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(bioskop1)
            }).then( b => {
                alert("Izmenili ste bioskop");
            })
        }
        else{
            alert("Unesite naziv bioskopa");
        }
    }
    
    IzbrisiBioskop(){
        let optionEl = this.kont.querySelector(".bioskopiIzb");
        var bioskopId = optionEl.options[optionEl.selectedIndex].value;
        console.log(bioskopId,optionEl);

        fetch("https://localhost:5001/Bioskop/Izbrisi?id="+bioskopId, {
            method: 'DELETE',
            }).then(p=>{
                alert("Izbrisali ste bioskop");
            })
        }
    

}
