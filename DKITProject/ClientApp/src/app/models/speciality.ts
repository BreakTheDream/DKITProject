export class SpecialityModel {
    id: number;
    name: string;
    content: string;
    imgIcon: string;
    controlNumber: number;
}

export class SpecialityPreviewModel {
    id: number;
    name: string;
    announce: string; 
    imgIcon: string;
}

export class AdministrationSpecialityModel {
    id: number;
    name: string;
    announce: string;
    content: string;
    imgIcon: string;
    controlNumberId: number;
    controlNumber: number;
}