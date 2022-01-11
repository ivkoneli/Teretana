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


        let kontForma =document.createElement("div");
        kontForma.className="Forma";
        this.container.appendChild(kontForma);


        this.crtajFormu(kontForma);

    }


    crtajFormu(host){
        let divzaIme = document.createElement("div");
        let l1 = document.createElement("label");
        let inputIme = document.createElement("input");
        inputIme.className="inputIme";
        l1.innerHTML ="Ime";
        divzaIme.appendChild(l1);
        divzaIme.appendChild(inputIme);
        host.appendChild(divzaIme);


        let divzaPrezime =document.createElement("div");
        let l2 = document.createElement("label");
        let inputPrezime = document.createElement("input");
        l2.innerHTML ="Prezime";
        divzaPrezime.appendChild(l2);
        divzaPrezime.appendChild(inputPrezime);
        host.appendChild(divzaPrezime);


        let divzaMail =document.createElement("div");
        let l5 = document.createElement("label");
        let inputEmail = document.createElement("input");
        l5.innerHTML ="Email";
        divzaMail.appendChild(l5);
        divzaMail.appendChild(inputEmail);
        host.appendChild(divzaMail);


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
            op.innerHTML = p.ime + p.prezime;
            op.value =p.id ;
            se.appendChild(op);         
        });
        host.appendChild(divzaTrenera);

        let divzClanarinu = document.createElement("div");
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

        let btnUclani = document.createElement("button");
        btnUclani.onclick=(ev)=>this.uclaniClana();
        btnUclani.innerHTML = "Uclani";
        host.appendChild(btnUclani);

    }

    uclaniClana(){

        let ime = this.container.querySelector("input");
        let prezime = this.container.querySelector("input");
        
        alert("Uclanio si se " + ime.value + prezime.value + " ide gas ");

    }
}