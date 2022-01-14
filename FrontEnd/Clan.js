export class Clan{


    constructor(id,ime,prezime,email,trener,clanarina,teretana) {
        this.id=id;
        this.ime=ime;
        this.prezime=prezime;
        this.email=email;
        this.trener=trener;
        this.clanarina=clanarina;
        this.teretana = teretana;
    }

    crtaj(host){

        var tr = document.createElement("tr");
        host.appendChild(tr);

        /*var el = document.createElement("td");
        el.innerHTML=this.id;
        tr.appendChild(el);*/

        /*let el = document.createElement("td");
        el.innerHTML=this.brKartice;
        tr.appendChild(el);*/

        let el = document.createElement("td");
        el.innerHTML=this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.email;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.trener;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.clanarina;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.teretana;
        tr.appendChild(el);

    }
}