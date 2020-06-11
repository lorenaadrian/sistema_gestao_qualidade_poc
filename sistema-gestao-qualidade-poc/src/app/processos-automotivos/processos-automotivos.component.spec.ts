import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessosAutomotivosComponent } from './processos-automotivos.component';

describe('ProcessosAutomotivosComponent', () => {
  let component: ProcessosAutomotivosComponent;
  let fixture: ComponentFixture<ProcessosAutomotivosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcessosAutomotivosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessosAutomotivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
