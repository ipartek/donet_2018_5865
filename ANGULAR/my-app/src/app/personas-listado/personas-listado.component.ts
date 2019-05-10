import { Component, OnInit } from '@angular/core';
import { Persona } from '../persona';
import { PersonaService } from '../persona.service';

@Component({
  selector: 'app-personas-listado',
  templateUrl: './personas-listado.component.html',
  styleUrls: ['./personas-listado.component.css']
})
export class PersonasListadoComponent implements OnInit {
  personas: Persona[];
  constructor(private personaService: PersonaService) {}

  ngOnInit(): void {
    this.personaService.getPersonas().subscribe(
      personas => this.personas = personas
    );
  }

}
