import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NaoConformidadeComponent } from './nao-conformidade.component';

describe('NaoConformidadeComponent', () => {
  let component: NaoConformidadeComponent;
  let fixture: ComponentFixture<NaoConformidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaoConformidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaoConformidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
