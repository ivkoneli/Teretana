export class Termin{


    constructor(id,pocetakTermina,krajTermina,clan,trener,teretana) {
        this.id=id;
        this.pocetakTermina=pocetakTermina;
        this.krajTermina=krajTermina;
        this.clan=clan;
        this.trener=trener;
        this.teretana=teretana;
    }

    crtaj(host){
        var tr = document.createElement("tr");
        host.appendChild(tr);

        let el1 = document.createElement("td");
        el1.innerText=this.pocetakTermina;
        tr.appendChild(el1);

        let el2 = document.createElement("td");
        el2.innerText=this.krajTermina;
        tr.appendChild(el2);

        let el3 = document.createElement("td");
        el3.innerText=this.clan;
        tr.appendChild(el3);

        let el4 = document.createElement("td");
        el4.innerText=this.trener;
        tr.appendChild(el4);

        let el5 = document.createElement("td");
        el5.innerText=this.teretana;
        tr.appendChild(el5);
    }
}