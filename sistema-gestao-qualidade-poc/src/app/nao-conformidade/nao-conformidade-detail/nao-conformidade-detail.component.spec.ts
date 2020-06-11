import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NaoConformidadeDetailComponent } from "./NaoConformidadeDetailComponent";

describe('NaoConformidadeDetailComponent', () => {
  let component: NaoConformidadeDetailComponent;
  let fixture: ComponentFixture<NaoConformidadeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaoConformidadeDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaoConformidadeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
