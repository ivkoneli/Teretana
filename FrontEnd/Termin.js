export class Termin{


    constructor(id,datum1,datum2,clan,trener) {
        this.id=id;
        this.datum1=datum1;
        this.datum2=datum2;
        this.clan=clan;
        this.trener=trener;
    }

    crtaj(host){
        var tr = document.createElement("tr");
        host.appendChild(tr);

        let el = document.createElement("td");
        el.innerHTML=this.datum1;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.datum2;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.clan;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.trener;
        tr.appendChild(el);
    }
}