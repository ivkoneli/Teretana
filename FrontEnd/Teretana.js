import { Clan } from "./Clan.js";

export class Teretana{


    constructor(listaClanova , listaTrenera, listaClanarina) {

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

        this.crtajTabelu(kontTabele);

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
        var zag=[/*"ID",*/"BROJKARTICE" , "IME" ,"PREZIME","EMAIL","TRENER","CLANARINA"];
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

        let btnUclani = document.createElement("button");
        btnUclani.onclick=(ev)=>this.uclaniClana();
        btnUclani.innerHTML = "Uclani";
        host.appendChild(btnUclani);


        let divTermin = document.createElement("div");
        divTermin.className="divzaTermin";
        let l6 = document.createElement("label");
        l6.innerHTML ="Termin";
        l6.className ="labelTermin";
        divTermin.appendChild(l6);
        let inputTermin =document.createElement("input")
        inputTermin.className="inputTermin";
        inputTermin.type = "Date";
        divTermin.appendChild(inputTermin);
        host.appendChild(divTermin);

        let btnRezervisi = document.createElement("button");
        btnRezervisi.onclick=(ev)=>this.rezervisiTermin();
        btnRezervisi.innerHTML = "Rezervisi";
        host.appendChild(btnRezervisi);
        
    }
    rezervisiTermin(){
        alert("Rezervisao si termin ,najjaci si !");
    }

    uclaniClana(){

        let ime = this.container.querySelector(".inputIme"); // Ime Clana
        let prezime = this.container.querySelector(".inputPrezime"); // Prezime Clana
        let email = this.container.querySelector(".inputEmail"); // Email Clana

        let optionCl = this.container.querySelector(".FormaselectClanarina");
        var clanarineID = optionCl.options[optionCl.selectedIndex].value; // IDClanarine 
        var clanarina = this.listaClanarina[clanarineID-1]; // objekat clanarine 


        let optionTr = this.container.querySelector(".FormaselectTrener");
        var treneriID = optionTr.options[optionTr.selectedIndex].value; // IDtrenera 
        var trener = this.listaTrenera[treneriID-1]; //objekat trenera 
       
        alert("Uclanio se novi korisink \n Ime : " + ime.value +
         "\n Prezime : " + prezime.value +
         "\n Email : " + email.value +
         "\n Clanarina : " + clanarina.naziv +
         "\n Trener :" + trener.ime + ' ' + trener.prezime );
         
         let c = new Clan(ime.value,prezime.value ,email.value,clanarineID,treneriID);
         this.listaClanova.push(c);
         console.log(c);
         console.log(this.listaClanova);

    }



    crtajFormuPretraga(host){

        let divSaznaj = document.createElement("div");
        let l1 = document.createElement("label");
        l1.className="labelSaznajVise";
        l1.innerHTML ="Saznaj Vise";
        divSaznaj.appendChild(l1);
        host.appendChild(divSaznaj);

        let divzClanarinu = document.createElement("div");
        divzClanarinu.className="divzaClanarinu";
        let l4 = document.createElement("label");
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
        btnPretrazi.innerHTML = "Pretrazi";
        host.appendChild(btnPretrazi);


        let divzaTrenera = document.createElement("div");
        let l3 = document.createElement("label");
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
        btnPretrazi2.innerHTML = "Pretrazi";
        host.appendChild(btnPretrazi2);

        let divzaDugmePrikaz =document.createElement("div");
        let btnPrikazClanova = document.createElement("button");
        btnPrikazClanova.className="btnPrikazClanova";
        btnPrikazClanova.onclick=(ev)=>this.prikazisveClanove();
        btnPrikazClanova.innerHTML = "PrikaziClanove";
        divzaDugmePrikaz.appendChild(btnPrikazClanova);
        host.appendChild(divzaDugmePrikaz);

       
    }
    prikazisveClanove(){

        alert("Crta se tabela clanova");
    }
    pretretraziTrenere(){
        
        let optionTr = this.container.querySelector(".selectTrener");
        var treneriID =optionTr.options[optionTr.selectedIndex].value;
        console.log(treneriID);
        var trener = this.listaTrenera[treneriID-1];
        alert("Trazi se trener : " + trener.ime + ' ' +  trener.prezime);


        fetch("https://localhost:5001/Clan/PreuzmiClanaT/"+ treneriID,
        {
            method:"GET"
        }).then(s=>{
                if(s.ok){

                    s.json().then(data =>{
                            console.log(data);
                            var teloTabele = document.querySelector(".TabelaPodaci");
                            data.forEach(c=>
                                {
                                    var trener = this.listaTrenera[c.trener-1];
                                    var clanarina = this.listaClanarina[c.clanarina-1];
                                    let cl = new Clan(c.id, c.brKartice , c.ime , c.prezime ,c.email ,trener.ime,clanarina.naziv);
                                    cl.crtaj(teloTabele);
                                })
                            
                    })
                }
        })
    }

    pretretraziClanarinu(){

        let optionCl = this.container.querySelector(".selectClanarina");
        var clanarineID =optionCl.options[optionCl.selectedIndex].value;
        console.log(clanarineID);
        var clanarina = this.listaClanarina[clanarineID-1];
        alert("Trazi se clanarina : " + clanarina.naziv);

        fetch("https://localhost:5001/Clan/PreuzmiClanaC/"+ clanarineID,
        {
            method:"GET"
        }).then(s=>{
                if(s.ok){

                    s.json().then(data =>{
                            console.log(data);
                            var teloTabele = document.querySelector(".TabelaPodaci");
                            data.forEach(c=>
                                {
                                    var trener = this.listaTrenera[c.trener-1];
                                    var clanarina = this.listaClanarina[c.clanarina-1];
                                    let cl = new Clan(c.id, c.brKartice , c.ime , c.prezime ,c.email ,trener.ime,clanarina.naziv);
                                    cl.crtaj(teloTabele);
                                })
                            
                    })
                }
        })

    }
}