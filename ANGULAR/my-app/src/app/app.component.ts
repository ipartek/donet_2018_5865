import { Component, OnInit } from '@angular/core';
import { Persona } from './persona';
import { PersonaService } from './persona.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  title = 'aplicación de demo';
  persona: Persona = {
    id: 0,
    nombre: 'Desconocido'
  };

  onClick(): void {
    console.log(this.persona.nombre);
  }
}
