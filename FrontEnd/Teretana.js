import { Clan } from "./Clan.js";
import { Termin } from "./Termin.js";
import { Trener } from "./Trener.js";
import { Clanarina } from "./Clanarina.js";

export class Teretana{


    constructor(id,naziv,listaClanova , listaTrenera, listaClanarina) {
        this.id = id;
        this.naziv = naziv;
        this.listaClanova =listaClanova;
        this.listaTrenera =listaTrenera;
        this.listaClanarina =listaClanarina;
        this.container =null;       
    }


    crtaj(host){
        this.container = document.createElement("div");
        this.container.className = "GlavniKontejner";
        host.appendChild(this.container);

        let Forme = document.createElement("div");
        Forme.className ="Forme";
        this.container.appendChild(Forme);


        let kontFormaUpis =document.createElement("div");
        kontFormaUpis.className="Forma";
        Forme.appendChild(kontFormaUpis);


        this.crtajFormu(kontFormaUpis);

        let kontFormaPretraga =document.createElement("div");
        kontFormaPretraga.className="Pretraga";
        Forme.appendChild(kontFormaPretraga);

        let kontTabele = document.createElement("div");
        this.container.appendChild(kontTabele);


        this.crtajFormuPretraga(kontFormaPretraga);

        //this.crtajTabelu(kontTabele);
        //this.crtajTabeluTermina(kontTabele);

    }
    crtajTabelu(host){

        let divTabela = document.createElement("div");
        divTabela.className ="divTabela";
        host.appendChild(divTabela);

        var tabela = document.createElement("table");
        tabela.className="Tabela";
        divTabela.appendChild(tabela);

        var tablehead = document.createElement("thead");
        tabela.appendChild(tablehead);

        var tablerow = document.createElement("tr");
        tablehead.appendChild(tablerow);

        var tablebody = document.createElement("tbody");
        tablebody.className = "TabelaPodaci";
        tabela.appendChild(tablebody);

        let th;
        var zag=["IME" ,"PREZIME","EMAIL","TRENER","CLANARINA","TERETANA"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tablerow.appendChild(th);
        })

    }
    crtajTabeluTermina(host){

        this.obrisiPrethodniSadrzaj();


        let divTabela = document.createElement("div");
        divTabela.className ="divTabelaTermina";
        host.appendChild(divTabela);

        var tabela = document.createElement("table");
        tabela.className="TabelaTermini";
        divTabela.appendChild(tabela);

        var tablehead = document.createElement("thead");
        tabela.appendChild(tablehead);

        var tablerow = document.createElement("tr");
        tablehead.appendChild(tablerow);

        var tablebody = document.createElement("tbody");
        tablebody.className = "TabelaPodaciTermini";
        tabela.appendChild(tablebody);

        let th;
        var zag=["POCETAK","KRAJ" , "CLAN" ,"TRENER","TERETANA"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tablerow.appendChild(th);
        })

    }


    crtajFormu(host){
        let divzaIme = document.createElement("div");
        divzaIme.className="divzaIme";
        let l1 = document.createElement("label");
        let inputIme = document.createElement("input");
        inputIme.className="inputIme";
        l1.className="labelIme";
        l1.innerHTML ="Ime";
        divzaIme.appendChild(l1);
        divzaIme.appendChild(inputIme);
        host.appendChild(divzaIme);


        let divzaPrezime =document.createElement("div");
        divzaPrezime.className="divzaPrezime";
        let l2 = document.createElement("label");
        let inputPrezime = document.createElement("input");
        inputPrezime.className="inputPrezime";
        l2.innerHTML ="Prezime";
        l2.className="labelPrezime";
        divzaPrezime.appendChild(l2);
        divzaPrezime.appendChild(inputPrezime);
        host.appendChild(divzaPrezime);


        let divzaMail =document.createElement("div");
        divzaMail.className="divzaMail";
        let l5 = document.createElement("label");
        let inputEmail = document.createElement("input");
        inputEmail.className="inputEmail";
        l5.innerHTML ="Email";
        l5.className = "labelEmail";
        divzaMail.appendChild(l5);
        divzaMail.appendChild(inputEmail);
        host.appendChild(divzaMail);


        let divzaTrenera = document.createElement("div");
        divzaTrenera.className="FormaDivzaTrenera";
        let l3 = document.createElement("label");
        l3.innerHTML ="Trener";
        l3.className="labelTrener";
        divzaTrenera.appendChild(l3);

        let se = document.createElement("select");
        se.className="FormaselectTrener";
        divzaTrenera.appendChild(se);

        let op;
        console.log(this.listaTrenera);
        this.listaTrenera.forEach(p => {
            op =document.createElement("option");
            op.innerHTML = p.ime + ' ' + p.prezime;
            op.value =p.id ;
            se.appendChild(op);         
        });
        host.appendChild(divzaTrenera);

        let divzClanarinu = document.createElement("div");
        divzClanarinu.className ="FormaDivzaClanarinu";
        let l4 = document.createElement("label");
        l4.innerHTML ="Clanarina";
        l4.className ="labelClanarina";
        divzClanarinu.appendChild(l4);

        let se1 = document.createElement("select");
        se1.className ="FormaselectClanarina";
        divzClanarinu.appendChild(se1);

        let op1;
        this.listaClanarina.forEach(p => {
            op1 =document.createElement("option");
            op1.innerHTML = p.naziv;
            op1.value =p.id ;
            se1.appendChild(op1);         
        });
        host.appendChild(divzClanarinu);

        let divzaUclani = document.createElement("div");
        divzaUclani.className ="divzaUclani";
        let btnUclani = document.createElement("button");
        btnUclani.onclick=(ev)=>this.uclaniClana();
        btnUclani.className = "btnUclani";
        btnUclani.innerHTML = "Uclani";
        divzaUclani.appendChild(btnUclani);

        let btnIspisi = document.createElement("button");
        btnIspisi.onclick=(ev)=>this.izbrisiClana();
        btnIspisi.className = "btnIspisi";
        btnIspisi.innerHTML = "Ispisi";
        divzaUclani.appendChild(btnIspisi);

        host.appendChild(divzaUclani);


        let divTermin = document.createElement("div");
        divTermin.className="divzaTermin";
        let l6 = document.createElement("label");
        l6.innerHTML ="Termin";
        l6.className ="labelTermin";
        divTermin.appendChild(l6);
        let inputTermin =document.createElement("input")
        inputTermin.className="inputTermin";
        inputTermin.type = "datetime";
        divTermin.appendChild(inputTermin);
        host.appendChild(divTermin);


        let divNoviTermin = document.createElement("div");
        divNoviTermin.className = "divzaNoviTermin";
        let l7 = document.createElement("label");
        l7.innerHTML ="NoviTermin";
        l7.className ="labelNoviTermin";
        divNoviTermin.appendChild(l7);
        let inputNoviTermin =document.createElement("input")
        inputNoviTermin.className="inputNoviTermin";
        inputNoviTermin.type = "datetime";
        divNoviTermin.appendChild(inputNoviTermin);
        host.appendChild(divNoviTermin);

        let divTermini = document.createElement("div");
        divTermini.className = "divTerminiDugme";
        let btnRezervisi = document.createElement("button");
        btnRezervisi.onclick=(ev)=>this.rezervisiTermin();
        btnRezervisi.className ="btnRezervisi";
        btnRezervisi.innerHTML = "Rezervisi";
        divTermini.appendChild(btnRezervisi);

        let btnIzmeni = document.createElement("button");
        btnIzmeni.onclick=(ev)=>this.izmeniTermin();
        btnIzmeni.className ="btnIzmeni";
        btnIzmeni.innerHTML = "Izmeni";
        divTermini.appendChild(btnIzmeni);

        host.appendChild(divTermini);




        let btnPrikaziT = document.createElement("button");
        btnPrikaziT.onclick=(ev)=>this.prikaziSveTermine();
        btnPrikaziT.className ="btnPrikaziTermine";
        btnPrikaziT.innerHTML = "PrikaziTermine";
        host.appendChild(btnPrikaziT);
        
    }
    izmeniTermin(){

        let podaci = [];
        podaci= this.prikupiInformacijeoClanu();
        let datum = document.querySelector(".inputTermin");
        let datumNovog = document.querySelector(".inputNoviTermin")

        fetch(`https://localhost:5001/Termin/IzmeniTermin/${podaci[0].value}/${podaci[1].value}/${podaci[2].value}/${this.id}/${datum.value}/${datumNovog.value}`,
        {
            method :"PUT",
            Headers:{
                "Content-Type":"application/json"
        },
            }).then(s=>{
                if(s.ok){
                    alert("Uspesno izmenjen termin ")
                    this.prikaziTermineClana(podaci);
                    //this.prikaziSveTermine();
                }
        })



    }
    rezervisiTermin(){

        let podaci = [];
        this.obrisiPrethodniSadrzajTermina(); 
        podaci = this.prikupiInformacijeoClanu();
        let datum = this.container.querySelector(".inputTermin");
        console.log(podaci[2]);
        

        fetch(`https://localhost:5001/Clan/PreuzmiClanaE/${this.id}/${podaci[2].value}`, // vraca ok ako je Novi korisnik i badrequest ako korisnik vec postoji
        {
            method:"GET",
        })
        .then(s=>{
            if(s.ok){
                alert("Nepostojeci clan !!! " + "\n Morate se prvo uclaniti u teretanu ");
            }
            else{
                fetch(`https://localhost:5001/Termin/VratiTermin/${this.id}/${datum.value}`,
        {
            method :"GET",
            Headers:{
                "Content-Type":"application/json"
            },
        }).then(s=>{
                if(s.ok){
                        //var clanarina = this.listaClanarina[podaci[3]-1];
                 var trener = this.listaTrenera.find(trener => trener.id == podaci[3]);
                console.log(podaci[3]);
                //date1 = datum.valueAsDate ;
                //var krajtermina = new Date(date1.getTime() + 60*60*100);
                alert("Korisnik je rezervisao novi termin" +  
                 "\n Ime : " + podaci[0].value +
                "\n Prezime : " + podaci[1].value +
                //"\n Email : " + podaci[2].value +
                //"\n Clanarina : " + clanarina.naziv +
                "\n Trener :" + trener.ime + ' ' + trener.prezime+
                "\n DatumP :" + datum.value +
                //"\n DatumK :" + krajtermina +
                 "\n Teretana :" + this.naziv);

                //this.prikaziTermineClana();

                fetch(`https://localhost:5001/Termin/DodajTermin/${podaci[0].value}/${podaci[1].value}/${podaci[2].value}/${datum.value}/${this.id}`,
                {
                    method :"POST",
                    Headers:{
                        "Content-Type":"application/json"
                },
                    }).then(s=>{
                        if(s.ok){
                            console.log(podaci);
                            this.prikaziTermineClana(podaci);
                            //this.prikaziSveTermine();
                        }
                })
                }
                else{
                    alert("Termin je vec zakazan !");
                }
        })
            }
 
        });
       
    }
    prikaziSveTermine(){
        //let listatermina = this.vratiTermine();
        //var telo = this.obrisiPrethodniSadrzajTermina(); // brise prethodnu tabelu (ako postoji) i opet je kreira praznu  i vrati nam tbody
       /* let datum = this.container.querySelector(".inputTermin"); 
        console.log(datum.value);

        listatermina.forEach(termin => {
            console.log(termin.pocetakTermina);
            
        });*/

       // if(listatermina.find(termin => termin.pocetakTermina.ToShortDateString() == datum.value) == null){
       //     alert ("Nepostojeci termin");
       // }
       // else{
            let kontTabeleTermini = document.createElement("div");
            this.obrisiPrethodniSadrzaj();
            this.obrisiPrethodniSadrzajTermina();
            this.container.appendChild(kontTabeleTermini);
            this.crtajTabeluTermina(kontTabeleTermini);
            var telo = document.querySelector(".TabelaPodaciTermini");
    
    
            fetch(`https://localhost:5001/Termin/PrikaziSveTermineClanova/${this.id}`,
            {
                method:"GET",
                Headers:{
                    "Content-Type":"application/json"
            },
            }).then(s=>{
                    if(s.ok){
                             //console.log(podaci);//var telo = this.obrisiPrethodniSadrzaj() 
                        s.json().then(data =>{
                                console.log(data);
                                //var teloTabele = document.querySelector(".TabelaPodaciTermini"); //tbody za tabelu koju smo napravili
                                data.forEach(tr=>
                                    {           
                                        var clan = this.listaClanova.find(clan => clan.id == tr.clan); // tr.clan je ID clana 
                                        var trener = this.listaTrenera.find(trener => trener.id == tr.trener); // IDtrenera      
                                        let t = new Termin(tr.id,tr.pocetakTermina,tr.krajTermina,clan.ime,trener.ime,this.naziv);
                                        t.crtaj(telo); // crtanje u tu tabelu 
                                    })
                                
                        })
                    }
            })
       // }
        
    }
    vratiTermine(){
        let listaTermina = [];
        fetch(`https://localhost:5001/Termin/PrikaziSveTermineClanova/${this.id}`,
            {
                method:"GET",
                Headers:{
                    "Content-Type":"application/json"
            },
            }).then(s=>{
                    if(s.ok){
                             //console.log(podaci);//var telo = this.obrisiPrethodniSadrzaj() 
                        s.json().then(data =>{
                                console.log(data);
                                //var teloTabele = document.querySelector(".TabelaPodaciTermini"); //tbody za tabelu koju smo napravili
                                data.forEach(tr=>
                                    {           
                                        var clan = this.listaClanova.find(clan => clan.id == tr.clan); // tr.clan je ID clana 
                                        var trener = this.listaTrenera.find(trener => trener.id == tr.trener); // IDtrenera      
                                        let t = new Termin(tr.id,tr.pocetakTermina,tr.krajTermina,clan.ime,trener.ime,this.naziv);
                                        listaTermina.push(t);
                                       // t.crtaj(telo); // crtanje u tu tabelu 
                                    })
                                
                        })
                    }
            })
            console.log(listaTermina);
            return listaTermina ;
    }
    prikaziTermineClana(podaci){
        //let podaci = [];
        //podaci = this.prikupiInformacijeoClanu();
        this.obrisiPrethodniSadrzajTermina();
        this.obrisiPrethodniSadrzaj();
        let kontTabeleTermini = document.createElement("div");
        this.container.appendChild(kontTabeleTermini);
        this.crtajTabeluTermina(kontTabeleTermini);
        var telo = document.querySelector(".TabelaPodaciTermini");


        fetch(`https://localhost:5001/Termin/PrikaziTermineClana/${podaci[0].value}/${podaci[1].value}/${podaci[2].value}/${this.id}`,
        {
            method:"GET",
            Headers:{
                "Content-Type":"application/json"
        },
        }).then(s=>{
                if(s.ok){
                    console.log(podaci);//var telo = this.obrisiPrethodniSadrzaj() 
                    s.json().then(data =>{
                            console.log(data);
                            //var teloTabele = document.querySelector(".TabelaPodaciTermini"); //tbody za tabelu koju smo napravili
                            data.forEach(tr=>
                                {           
                                    var clan = this.listaClanova.find(clan => clan.id == tr.clan); // tr.clan je ID clana 
                                    var trener = this.listaTrenera.find(trener => trener.id == tr.trener); // IDtrenera      
                                    let t = new Termin(tr.id,tr.pocetakTermina ,tr.krajTermina,clan.ime,trener.ime,this.naziv);
                                    t.crtaj(telo); // crtanje u tu tabelu 
                                })
                            
                    })
                }
        })
    }
    obrisiPrethodniSadrzajTermina(){
        if(document.querySelector(".TabelaTermini") !=null){
            var tabela = document.querySelector(".TabelaTermini");
            var roditelj = tabela.parentNode;
            roditelj.removeChild(tabela);
            let kontTabeleTermini = document.createElement("div");
            this.container.appendChild(kontTabeleTermini);
           // this.crtajTabeluTermina(kontTabeleTermini);
            return document.querySelector(".TabelaPodaciTermini");

        }
        else
        {
            let kontTabeleTermini = document.createElement("div");
            this.container.appendChild(kontTabeleTermini);
            //this.crtajTabeluTermina(kontTabeleTermini);
            return document.querySelector(".TabelaPodaciTermini");

        } 
    }
    prikupiInformacijeoClanu(){
        let ime = this.container.querySelector(".inputIme"); // Ime Clana
        let prezime = this.container.querySelector(".inputPrezime"); // Prezime Clana
        let email = this.container.querySelector(".inputEmail"); // Email Clana

        let optionCl = this.container.querySelector(".FormaselectClanarina");
        var clanarineID = optionCl.options[optionCl.selectedIndex].value; // IDClanarine 
        //var clanarina = this.listaClanarina[clanarineID-1]; // objekat clanarine 


        let optionTr = this.container.querySelector(".FormaselectTrener");
        var treneriID = optionTr.options[optionTr.selectedIndex].value; // IDtrenera 
        //var trener = this.listaTrenera[treneriID-1]; //objekat trenera

        let informacije =[];
        informacije[0]=ime ;informacije[1]=prezime;informacije[2]=email;informacije[4]=clanarineID;informacije[3]=treneriID;
        return informacije;

    }
    uclaniClana(){
        let podaci = [];
        podaci = this.prikupiInformacijeoClanu();
        console.log(podaci[2].value);
        console.log(podaci[4],podaci[3]);


        var clanarina = this.listaClanarina.find(clanarina => clanarina.id == podaci[4]);
        var trener = this.listaTrenera.find(trener => trener.id == podaci[3]);
 
        fetch(`https://localhost:5001/Clan/PreuzmiClanaE/${this.id}/${podaci[2].value}`, // vraca ok ako je NOVI clan ,vraca badrequest ako clan vec postoji 
        
        {
        method: "GET",
        Headers:{
            "Content-Type":"application/json"
        },
        }).then(s=>{
            if(s.ok){

                

                alert("Uclanio se novi korisink" +  
                "\n Ime : " + podaci[0].value +
                "\n Prezime : " + podaci[1].value +
                "\n Email : " + podaci[2].value +
                "\n Clanarina : " + clanarina.naziv +  
                "\n Trener :" + trener.ime + ' ' + trener.prezime +
                "\n Teretana" + this.naziv );
         
                 //this.prikazisveClanove();
        
                fetch(`https://localhost:5001/Clan/Uclani/${podaci[0].value}/${podaci[1].value}/${podaci[2].value}/${podaci[3]}/${podaci[4]}/${this.id}`,
        
                {
                    method: "POST",
                    Headers:{
                        "Content-Type":"application/json"
                     },
                    }).then(s=>{
                    if(s.ok){
                        console.log(this.listaClanova);
                        this.prikazisveClanove();
                    }
                 }
            )         
               
               }
            else{
                alert("Korisnik vec postoji !");
            }   
           }
       )         
        
       /* else if(clan != null){
            alert ("Vec ste uclanjeni !!!");
        }
        else{
            alert("Muda");
        }*/

         //let c = new Clan(ime.value,prezime.value ,email.value,clanarineID,treneriID);
         //this.listaClanova.push(c);
         //console.log(c);
         //console.log(this.listaClanova);
         //this.prikazisveClanove();

    }
    izbrisiClana(){
        let podaci = [];
        podaci = this.prikupiInformacijeoClanu();
        
        fetch(`https://localhost:5001/Clan/IzbrisiClana/${podaci[0].value}/${podaci[1].value}/${podaci[2].value}/${this.id}`,
        
                {
                    method: "DELETE",
                    Headers:{
                        "Content-Type":"application/json"
                     },
                    }).then(s=>{
                    if(s.ok){
                        alert("Korisnik " + podaci[0].value +" je obrisan !")      
                        console.log(this.listaClanova);
                        this.prikazisveClanove();
                    }
                 })
    }



    crtajFormuPretraga(host){

        let divSaznaj = document.createElement("div");
        divSaznaj.className="divSaznajvise";
        let l1 = document.createElement("label");
        l1.className="labelSaznajVise";
        l1.innerHTML ="Saznaj Vise";
        divSaznaj.appendChild(l1);
        host.appendChild(divSaznaj);

        let divzClanarinu = document.createElement("div");
        divzClanarinu.className="divzaClanarinu";
        let l4 = document.createElement("label");
        l4.className ="labelPretragaClanarina";
        l4.innerHTML ="Clanarina";
        divzClanarinu.appendChild(l4);

        let se1 = document.createElement("select");
        se1.className ="selectClanarina"
        divzClanarinu.appendChild(se1);

        let op1;
        this.listaClanarina.forEach(p => {
            op1 =document.createElement("option");
            op1.innerHTML = p.naziv;
            op1.value =p.id ;
            se1.appendChild(op1);         
        });
        host.appendChild(divzClanarinu);

        let btnPretrazi = document.createElement("button");
        btnPretrazi.onclick=(ev)=>this.pretretraziClanarinu();
        btnPretrazi.className ="btnPretraga";
        btnPretrazi.innerHTML = "Pretrazi";
        host.appendChild(btnPretrazi);


        let divzaTrenera = document.createElement("div");
        divzaTrenera.className = "divzaTrenera";
        let l3 = document.createElement("label");
        l3.className ="labelPretragaTrener";
        l3.innerHTML ="Trener";
        divzaTrenera.appendChild(l3);

        let se = document.createElement("select");
        se.className="selectTrener";
        divzaTrenera.appendChild(se);

        let op;
        this.listaTrenera.forEach(p => {
            op =document.createElement("option");
            op.innerHTML = p.ime + ' ' + p.prezime;
            op.value =p.id ;
            se.appendChild(op);         
        });
        host.appendChild(divzaTrenera);

        let btnPretrazi2 = document.createElement("button");
        btnPretrazi2.onclick=(ev)=>this.pretretraziTrenere();
        btnPretrazi2.className ="btnPretraga";
        btnPretrazi2.innerHTML = "Pretrazi";
        host.appendChild(btnPretrazi2);

        //let divzaDugmePrikaz =document.createElement("div");
        let btnPrikazClanova = document.createElement("button");
        btnPrikazClanova.className="btnPrikazClanova";
        btnPrikazClanova.onclick=(ev)=>this.prikazisveClanove();
        btnPrikazClanova.innerHTML = "PrikaziTeretanu";
        //divzaDugmePrikaz.appendChild(btnPrikazClanova);
        host.appendChild(btnPrikazClanova);

       
    }

    obrisiPrethodniSadrzaj(){

        //var tabela = document.querySelector(".Tabela");
        //var roditelj = tabela.parentNode;
        //roditelj.removeChild(tabela);

       // this.crtajTabelu(roditelj);

        if(document.querySelector(".Tabela") !=null){
            var tabela = document.querySelector(".Tabela");
            var roditelj = tabela.parentNode;
            roditelj.removeChild(tabela);
            //this.crtajTabelu(roditelj);
            return document.querySelector(".TabelaPodaci");

        }
        else
        {
            let kontTabela = document.createElement("div");
            this.container.appendChild(kontTabela);
            //this.crtajTabelu(kontTabela);
            return document.querySelector(".TabelaPodaci");

        } 

        //var teloTabele = document.querySelector(".TabelaPodaci");
        //var roditelj = teloTabele.parentNode;
        //roditelj.removeChild(teloTabele);

        //teloTabele = document.createElement("tbody");
        //teloTabele.className="TabelaPodaci";
        //roditelj.appendChild(teloTabele);

       // var teloTabele = document.querySelector(".TabelaPodaci");
        //return teloTabele;

    }
    prikazisveClanove(){
        this.obrisiPrethodniSadrzajTermina();
        this.obrisiPrethodniSadrzaj();
        let kontTabela = document.createElement("div");
        this.container.appendChild(kontTabela);
        this.crtajTabelu(kontTabela);
        var telo =  document.querySelector(".TabelaPodaci");


        fetch(`https://localhost:5001/Clan/PreuzmiClana/${this.id}`,
        {
            method:"GET"
        }).then(s=>{
                if(s.ok){
                         //var telo = this.obrisiPrethodniSadrzaj()
                    s.json().then(data =>{
                            console.log(data);
                            //var teloTabele = document.querySelector(".TabelaPodaci");
                            data.forEach(c=>
                                {
                                    console.log(c.trener);
                                    let trener = this.listaTrenera.find(trener => trener.id == c.trener);
                                    let clanarina = this.listaClanarina.find(clanarina => clanarina.id == c.clanarina);
                                    let imeT = this.naziv;                                 
                                    let cl = new Clan(c.id,c.ime , c.prezime ,c.email ,trener.ime,clanarina.naziv,imeT);
                                    console.log(cl);
                                    cl.crtaj(telo);
                                })
                            
                    })
                }
        })
    
        
    }
    pretretraziTrenere(){
        
        this.obrisiPrethodniSadrzajTermina();
        this.obrisiPrethodniSadrzaj();
        let kontTabela = document.createElement("div");
        this.container.appendChild(kontTabela);
        this.crtajTabelu(kontTabela);
        var telo =  document.querySelector(".TabelaPodaci");

        let optionTr = this.container.querySelector(".selectTrener");
        var treneriID =optionTr.options[optionTr.selectedIndex].value;
        console.log(treneriID);
        var trener = this.listaTrenera.find(trener => trener.id == treneriID)
        alert("Trazi se trener : " + trener.ime + ' ' +  trener.prezime);


        fetch(`https://localhost:5001/Clan/PreuzmiClanaT/${treneriID}/${this.id}`,
        {
            method:"GET"
        }).then(s=>{
                if(s.ok){
                    //var telo = this.obrisiPrethodniSadrzaj();
                    s.json().then(data =>{
                            console.log(data);
                            //var teloTabele = document.querySelector(".TabelaPodaci");
                            data.forEach(c=>
                                {
                                    let trener = this.listaTrenera.find(trener => trener.id == c.trener);
                                    let clanarina = this.listaClanarina.find(clanarina => clanarina.id == c.clanarina);
                                    let imeT = this.naziv;
                                    let cl = new Clan(c.brKartice , c.ime , c.prezime ,c.email ,trener.ime,clanarina.naziv,imeT);
                                    cl.crtaj(telo);
                                })
                            
                    })
                }
        })
    }

    pretretraziClanarinu(){

        //this.obrisiPrethodniSadrzajTermina();
        this.obrisiPrethodniSadrzajTermina();
        this.obrisiPrethodniSadrzaj();
        let kontTabela = document.createElement("div");
        this.container.appendChild(kontTabela);
        this.crtajTabelu(kontTabela);
        var telo =  document.querySelector(".TabelaPodaci");

        let optionCl = this.container.querySelector(".selectClanarina");
        var clanarineID =optionCl.options[optionCl.selectedIndex].value;
        console.log(clanarineID);
        var clanarina = this.listaClanarina.find(clanarina => clanarina.id == clanarineID);
        alert("Trazi se clanarina : " + clanarina.naziv);

        fetch(`https://localhost:5001/Clan/PreuzmiClanaC/${clanarineID}/${this.id}`,
        {
            method:"GET"
        }).then(s=>{
                if(s.ok){
                    //var telo = this.obrisiPrethodniSadrzaj();
                    s.json().then(data =>{
                            console.log(data);
                            //var teloTabele = document.querySelector(".TabelaPodaci");
                            data.forEach(c=>
                                {
                                    
                                    let trener = this.listaTrenera.find(trener => trener.id == c.trener);
                                    let clanarina = this.listaClanarina.find(clanarina => clanarina.id == c.clanarina);
                                    let imeT = this.naziv ;
                                    let cl = new Clan(c.brKartice , c.ime , c.prezime ,c.email ,trener.ime,clanarina.naziv,imeT);
                                    cl.crtaj(telo);
                                })
                            
                    })
                }
        })

    }
}