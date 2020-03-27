import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-simulador-data',
  templateUrl: './simulador.component.html'
})
export class SimuladorComponent {
  public materias: Materia[];
  public escolas: Escola[];
  public formData: any;
  public url: string;
  public done: boolean;
  public loading: boolean;
  public showForm: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.formData = {};
    this.url = baseUrl;
    this.materias = [];
    this.formData['materias'] = this.materias;
    this.done = false;
    this.showForm = true;
  }

  simulate() {
      this.showForm = false;
      this.loading = true;
      const headers = { 'Content-Type': 'application/json' };
      return this.http.post(this.url + 'periodo/gerarperiodo', JSON.stringify(this.formData), { headers }).subscribe(result => {
          console.log("done");
          this.done = true;
          this.loading = false;
      },
      error => {
          console.error(error);
          this.loading = false;
          this.showForm = true;
      });
  }

  edit(data) {
      //console.log(data.name + " - " + data.value);
      this.formData[data.name] = data.value;
  }

  editMateria(data) {
      //console.log(data);
      this.formData.materias[data.id][data.name] = data.value;
      //console.log(this.formData);
  }

  totalMaterias(m) {
      var len = parseInt(m);
      if (len > this.materias.length) {
          for (let i = this.materias.length; i < len; i++) {
              let materia = { id: i } as Materia;
              this.materias.push(materia);
          }
      } else if (len < this.materias.length) {
          for (let i = this.materias.length; i > len; i--) {
              this.materias.splice(i - 1, 1);
          }
      }
  }

}

interface Escola {
    id: number;
    nome: string;
    endereco: string;
    telefone: string;
    dataCriacao: Date;
}

interface Materia {
    id: number;
    nome: string;
    peso1: number;
    peso2: number;
    peso3: number;
}
