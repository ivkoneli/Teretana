export class Trener{


    constructor(id,brLicence,ime,prezime,plata,teretana) {
        this.id =id;
        this.brLicence=brLicence;
        this.ime=ime;
        this.prezime=prezime;
        this.plata=plata; 
        this.teretana =teretana;       
    }

    ime() {
        return this.ime;
    }
}