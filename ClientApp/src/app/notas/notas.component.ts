import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-notas-data',
  templateUrl: './notas.component.html'
})
export class NotasComponent {
  public alunos: Aluno[];
  public selectedAluno: Aluno;
  public formData: any;
  public url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Aluno[]>(baseUrl + 'periodo/obteralunos').subscribe(result => {
      this.alunos = result;
    }, error => console.error(error));
    this.formData = new FormData();
    this.url = baseUrl;
    this.selectedAluno = null;
  }

  create() {
      console.log(this.formData);
      const headers = { 'Content-Type': 'application/json' };
      return this.http.post(this.url + 'escola/criarescola', JSON.stringify(this.formData), { headers }).subscribe(result => {
          console.log(result);
      }, error => console.error(error));
  }

  edit(data) {
      console.log(data.name + " - " + data.value);
      this.formData[data.name] = data.value;
    }

    verNotas(aluno) {
        console.log(aluno);
        this.selectedAluno = aluno;
    }

    dismissModal() {
        this.selectedAluno = null;
    }

}

interface Materia {
    nome: string
}

interface Nota {
    materia: Materia,
    nota1: number,
    nota2: number,
    nota3: number,
    nota4: number,
    isAprovado: boolean
}

interface Turma {
    nome: string
}

interface Aluno {
    nome: string,
    dataNascimento: Date,
    turma: Turma,
    notas: Nota[],
    isAprovado: boolean
}
