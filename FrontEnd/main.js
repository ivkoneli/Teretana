import { Clan } from "./Clan.js";
import { Teretana } from "./Teretana.js";
import { Clanarina } from "./Clanarina.js";
import {Trener} from "./Trener.js";

var listaclanova =[];
var listatrenera =[];
var listaclanarina =[];
var listateretana = [];


fetch("https://localhost:5001/Clan/PreuzmiClana")
.then(p=>{
    p.json().then(clanovi =>{
        clanovi.forEach(clan=> {
            var c = new Clan(clan.id , clan.ime ,clan.prezime ,clan.email,clan.trener ,clan.clanarina,clan.teretana);
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
                fetch("https://localhost:5001/Teretana/Teretane")
                .then(p=>{
                    p.json().then(teretane =>{
                        teretane.forEach(teretana =>{
                            var T = new Teretana(teretana.id,teretana.naziv,listaclanova,listatrenera,listaclanarina);
                            listateretana.push(T);
                            //T.crtaj(document.body);
                        });

                
                    })
                    console.log(listateretana);
                    let teretana = listateretana.find(teretana => teretana.id == 1); // pozivamo crtaj za izabranu teretanu 
                    console.log(teretana);
                    console.log(listateretana[1]);
                    })

                })
                console.log(listatrenera);
            });

        })
    console.log(listaclanarina);
});



//teretana.crtaj(document.body);

