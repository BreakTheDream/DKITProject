export class SpecialityModel {
    constructor(
        public id: number,
        public name: string,
        public content: string,
        public imgIcon: string
    ){}
}

export class SpecialityPreviewModel {
    constructor(
        public id: number,
        public name: string,
        public announce: string, 
        public imgIcon: string
    ){}
}

export class AdministrationSpecialityModel {
    constructor(
        public id: number,
        public name: string,
        public announce: string,
        public content: string,
        public imgIcon: string,
        public controlNumberId: number,
        public controlNumber: number,
    ){}
}