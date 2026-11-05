import { Component, inject, output, signal } from '@angular/core';
import { form, FormField, minLength, required } from '@angular/forms/signals';
import { ButtonDirective } from 'primeng/button';
import { Ripple } from 'primeng/ripple';

import { HorarioService } from '../../../core/services/horario/horario.service';
import { AlertService } from '../../../shared/services/alert.service';
import { HorarioRequest } from '../../../request/horario/horario.request';

interface HorarioModel {
  nombre: string;
  descripcion: string;
  estado: string;
  tipo: string;
  turno: string;
  fechaInicio: string;
  fechaFin: string;
  horaInicio: string;
  horaFin: string;
  horaAperturaIngreso: string;
  horaCierreIngreso: string;
  tolerancia: string;
}

@Component({
  selector: 'app-horario-register',
  imports: [FormField, ButtonDirective, Ripple],
  templateUrl: './horario-register.html',
  styleUrl: './horario-register.scss',
})
export class HorarioRegister {
  private readonly horarioService = inject(HorarioService);
  private readonly alert = inject(AlertService);

  protected readonly close = output();
  protected readonly saved = output();

  protected readonly model = signal<HorarioModel>({
    nombre: '',
    descripcion: '',
    estado: '1',
    tipo: '',
    turno: '',
    fechaInicio: '',
    fechaFin: '',
    horaInicio: '',
    horaFin: '',
    horaAperturaIngreso: '',
    horaCierreIngreso: '',
    tolerancia: '',
  });

  protected readonly saving = signal(false);

  protected readonly form = form(this.model, (schema) => {
    required(schema.nombre, { message: 'El nombre es obligatorio.' });
    minLength(schema.nombre, 3, { message: 'El nombre debe tener al menos 3 caracteres.' });
  });

  protected onSubmit(): void {
    if (this.form().invalid() || this.saving()) {
      return;
    }

    const m = this.model();
    const payload: HorarioRequest = {
      nombre: m.nombre,
      estado: m.estado !== '' ? Number(m.estado) : null,
      tipo: m.tipo !== '' ? Number(m.tipo) : null,
      turno: m.turno || null,
      fechaInicio: m.fechaInicio || null,
      fechaFin: m.fechaFin || null,
      horaInicio: m.horaInicio || null,
      horaFin: m.horaFin || null,
      horaAperturaIngreso: m.horaAperturaIngreso || null,
      horaCierreIngreso: m.horaCierreIngreso || null,
      tolerancia: m.tolerancia || null,
      descripcion: m.descripcion,
    };

    this.saving.set(true);
    this.horarioService.Register(payload).subscribe({
      next: (res) => {
        this.saving.set(false);
        if (res.isSuccess) {
          this.alert.success('Registro', 'Horario registrado correctamente.');
          this.saved.emit();
          this.close.emit();
        } else {
          this.alert.error('Error', res.message ?? 'No se pudo registrar el horario.');
        }
      },
      error: () => {
        this.saving.set(false);
        this.alert.error('Error', 'No se pudo registrar el horario.');
      },
    });
  }
}
