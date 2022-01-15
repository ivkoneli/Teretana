import { Clan } from "./Clan.js";
import { Teretana } from "./Teretana.js";
import { Clanarina } from "./Clanarina.js";
import {Trener} from "./Trener.js";

var listaclanova =[];
var listatrenera =[];
var listaclanarina =[];
var listateretana = [];

function crtajSelect() {

        let divTeretana = document.createElement("div");
        divTeretana.className ="divTeretana";

        let divzaTeretanu = document.createElement("div");
        divzaTeretanu.className="divzaTeretanu";
        let l1 = document.createElement("label");
        l1.innerHTML ="Teretana";
        l1.className="labelTeretana";
        divzaTeretanu.appendChild(l1);
        divTeretana.appendChild(divzaTeretanu);
        document.body.appendChild(divTeretana);

        let se = document.createElement("select");
        se.className="selectTeretana";
        divzaTeretanu.appendChild(se);

        let op1;     
        op1 =document.createElement("option");
        op1.innerHTML = "OneWellness";
        op1.value = 1;
        se.appendChild(op1);
        let op2;     
        op2 =document.createElement("option");
        op2.innerHTML = "Kangoo";
        op2.value = 2;
        se.appendChild(op2);
        //let teretanaID ;
        //se.onchange=(ev)=>{teretanaID =optionCl.options[optionCl.selectedIndex].value;}

        let optionCl = divTeretana.querySelector(".selectTeretana");
        //var teretanaID = optionCl.options[optionCl.selectedIndex].value;


        let btnPrikazi = document.createElement("button");
        btnPrikazi.onclick=(ev)=>preuzmiPodatkeoTeretani();
        btnPrikazi.className = "btnPrikazi";
        btnPrikazi.innerHTML = "Prikazi";
        divzaTeretanu.appendChild(btnPrikazi);

        
    
}

function obrisiForme(teretana) {
    if(document.querySelector(".GlavniKontejner") !=null){
        var glavniDIV = document.querySelector(".GlavniKontejner");
        var roditelj = glavniDIV.parentNode;
        roditelj.removeChild(glavniDIV);
        teretana.crtaj(document.body);
        //return document.querySelector(".TabelaPodaci");

    }
    else
    {
        let glavniDIV = document.createElement("div");
        document.body.appendChild(glavniDIV);
        teretana.crtaj(document.body);
        //return document.querySelector(".TabelaPodaci");

    } 
    
}
function preuzmiPodatkeoTeretani()
{   
    let optionCl = document.body.querySelector(".selectTeretana");
    var teretanaID = optionCl.options[optionCl.selectedIndex].value;
    console.log(teretanaID);
    listatrenera = [];
    listaclanarina = [];
    listaclanova = [];


    fetch(`https://localhost:5001/Clan/PreuzmiClana/${teretanaID}`)
    .then(p=>{
        p.json().then(clanovi =>{
            clanovi.forEach(clan=> {
                var c = new Clan(clan.id , clan.ime ,clan.prezime ,clan.email,clan.trener ,clan.clanarina,clan.teretana);
                listaclanova.push(c);
            });

        })
    });
    console.log(listaclanova);


    fetch(`https://localhost:5001/Clanarina/Clanarine/${teretanaID}`)
    .then(p=>{
        p.json().then(clanarine =>{
            clanarine.forEach(clanarina =>{
                var cl = new Clanarina(clanarina.id, clanarina.naziv, clanarina.cena,clanarina.teretana);
                listaclanarina.push(cl);
            });
            fetch(`https://localhost:5001/Trener/Treneri/${teretanaID}`)
            .then(p=>{
                p.json().then(treneri =>{
                    treneri.forEach(trener =>{
                        var t = new Trener(trener.id, trener.brLicence , trener.ime , trener.prezime , trener.plata,trener.teretana);
                        listatrenera.push(t);
                       

                    });
                    let naziv ;
                    if (teretanaID == 1)
                    {
                        naziv = "OneWellness";
                    }
                    else{
                        naziv ="Kangoo";
                     }
            
                    let teretana = new Teretana(teretanaID,naziv,listaclanova,listatrenera,listaclanarina);
                    obrisiForme(teretana);
                   // teretana.crtaj(document.body);

                })
                console.log(listatrenera);
            });

        })
        console.log(listaclanarina);

    })
    
}

fetch("https://localhost:5001/Teretana/Teretane")
    .then(p=>{
        p.json().then(teretane =>{
            teretane.forEach(teretana =>{
                let naziv = teretana.naziv;
                let id = teretana.id;
                var T = new Teretana();
                T.naziv = naziv;
                T.id= id;
                listateretana.push(T);          
            });
        })        
        console.log(listateretana);
        crtajSelect();

    });
