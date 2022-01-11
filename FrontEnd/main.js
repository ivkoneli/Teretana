import { Clan } from "./Clan.js";
import { Teretana } from "./Teretana.js";
import { Clanarina } from "./Clanarina.js";
import {Trener} from "./Trener.js";

var listaclanova =[];
var listatrenera =[];
var listaclanarina =[];


fetch("https://localhost:5001/Clan/PreuzmiClana")
.then(p=>{
    p.json().then(clanovi =>{
        clanovi.forEach(clan=> {
            var c = new Clan(clan.id , clan.brKartice, clan.ime ,clan.prezime ,clan.email);
            listaclanova.push(c);
        })


    })
});
console.log(listaclanova);


fetch("https://localhost:5001/Clanarina/Clanarine")
.then(p=>{
    p.json().then(clanarine =>{
        clanarine.forEach(clanarina =>{
            var cl = new Clanarina(clanarina.id, clanarina.naziv, clanarina.cena);
            listaclanarina.push(cl);
        });
        fetch("https://localhost:5001/Trener/Treneri")
        .then(p=>{
            p.json().then(treneri =>{
                treneri.forEach(trener =>{
                    var t = new Trener(trener.id, trener.brLicence , trener.ime , trener.prezime , trener.plata);
                    listatrenera.push(t);
                });
                    var T = new Teretana(listaclanova,listatrenera,listaclanarina);
                    T.crtaj(document.body);
                })
                console.log(listatrenera);
            });

        })
    console.log(listaclanarina);
});

