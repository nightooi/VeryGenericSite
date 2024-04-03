const items = $('.card.text-white');
//refragment this into module patter tomorrow.
module.exports = selectedElements;
const __jqWrapperElement__proto__ = {
     
    get getSelector() {
        return this.selector;
    },
    set selector(selector) {
        //call the wrapper from here and populate the object during construction.
        this.selector = selector;
    },
    get getIsAttributeSeperate() {
        return this.isSeperate;
    },
    //need to define if Attribute is going to be chained to css || id 
    //eg. .selector[attribute] || .selector, [attribute];
    set setIsAttributeSeperate(mode = Boolean) {
        if (!isBoolean(mode)) {
            throw new Error("Wrong type supplied to isFuzzy, needs to be a true/false");
            this.isSeperate = mode;
        }
    },

}
Object.defineProperty(__jqWrapperElement__proto__, selector, {
    value: String,
    writable: false,
    enumerable: false,
    configurable: false,
})
Object.assign(SelectElements.prototype, __jqwrapper__proto__)

//run creationLogic in here
function SelectElements() { //inherits from WrapperElement, Has htmlElementField which will be populated depeding on logic/info supplied to other fields
}
//delegate some creationLogic to this itemspecific
function Element() { //inherits something... from Attribute, CssSelector, IdSelector, AttributeSelector
}
function AttributeSelector() { //inherits from checkInput
}
function CssSelector() { //inherits from checkInput
}
function IdSelector() { //inherits from checkInput
}
function Parent() { //inherits from WrapperElement
}
function Child() { //inherits from WrapperElement
}
function NodeSibling() { //maybe?? this really makes the search hard. inherits from sibling
   //nodeSiblings means siblings within the current node branch. 
}
function TreeSibling() { //maybe?? this effectivily makes the search impossible... inherits from sibling
   //tree siblings means siblings across all nodeBranches in current document
}
function Sibling() {
    /*
    * sibling could be defined as if stric flag is set: sibling is of the same element type eg only a div can be a sibling of div
    * else if strict is not set: sibling is of the same statment type: EG: block level statement p can be a sibling of div
    *                            if div is declared as block... etc...
    * 
    * if strict: element nesting in the nodeTree must be of the exact same type as sibling
    * if not strict: element nesting path in the nodeTree must follow same structure as sibling 
    *   eg. if sibling is nested in 2 block level statements elemnts nested in 2 block level statements are its siblings
    */
}
function CheckInput(value, expected, structure) { //imperative statements Monad

}
const __inputChecker__prototype__ = {
    isType: (function (expected) {

        return {
            
        }
    }),
    isStructured: (function (expected) {

        return {
            
        }
    }),
    allowed: (function (types) {
        
        return {
            
        }
    }),
    restructure: (function (input) {
            
        return {
            
        }
    })
}

Object.Assign(CheckInput.prototype, __inputChecker__prototype__)

function selectByParent(items, Selector, Validator ) {
    for (let i = 0; i > items.length; i++) {
        if (items[i].parent().is(Selector));
    }
}
const selectionObject = {
    selector: {
        id: 'id',
        class: 'class',
        css: [{ 'css': 'value' }, { 'css': 'value' }],
        attribute: [{ 'attribute': value | { values = 'string' | 'string '  | 'string, ' } | 'string string' | 'string'  }]
    },
    parent: Object.assign(selectionObject.parent, selector),
    child: Object.assign(selectionObject.parent, selector),
}
const selection = {
    selector: [{
        id: 'id',
        class: ['class',],
        css: {
            value: [{ 'css': value }, {}],
            flagComputed: false,
        },
        
    }],
    parent: Object.assing(selection.parent, selector),
    child: Object.assign(selection.child, selector),
    attribute: Object.assign(selection.attribute, selectionObject.attribute)
}
function jqInputValidate(selector = selectionObject || "window") {
    

}
function _isString(key) {

    if (typeof (key) === 'stirng' || key instanceof String) {
        return true;
    }
    if (key === undefined) {
        return _isString(this.selector);
    }
    return false;
}
async function jqInputConverter(i, id = false) {
    
    if (Number.isInteger(i)) {
        return _jqInputTypehelper(new String(i));
    } else if (Array.isArray(i)) {
    }

}
// this can hang because of cirucular references, needs to be rewritten.
// also handling cases for maps sets and other stuff... not worth it 
// for now me thinks
async function _jqObjectToArrayConverterHelper(i, depthlimit) {
    
    if (_isArray(i)){
        let jagged = new Array()
        return each(i, (i, elem) => {
            if (typeof(elem) === 'object') {
                return (jagged[i] = await _jqSearchObjectHelper(elem, 0));
            }
        })
    }
}
async function _jqsSearchObjectHelper(i, currdepth, depthlimit, regex, funcOnRegexMatch) {
    if (depth > depthlimit) {
        debugger
        console.log(`${this._jqSearchObjectHelper} depth::
        ${depth}, is too high, input object is malformed!`)
    }
    if (_isArray(i)) {
        let a = new Array();
        return each(i, (index, elem) => {
            if (_isString(elem) && _isString(i[index][elem])) {
                return a[index][elem] = i[elem]
            }else if (typeof (elem) === 'object' || typeof(i[elem]) === 'object') {
                return (a[i][elem] = await _jqSearchObjectHelper(i[elem], depth + 1, regex, funcOnRegexMatch));
            }
        })
    }
}
function _isValuePairOfStrings(i) {
    if (_undefinedCheck(i)) {
        return false;
    }
    if (_isStringKey(i) && _isKeyValueString(i)) {
        return true;
    }
    return false;
}
function _isKeyValueString(i) {
    if (_undefinedCheck(i)) {
        throw new Error(_typeNullValueErrorMessage(_isKeyString, i));
    }
    if (!_isString(i)) {
        return false;
    }
    return true;
}
function _typeNullValueErrorMessage(func, param) {
    if (_undefinedCheck([func, param])){
        return `Error at type conversion, 
        input value to converter is undefined`;
    }
    return `Error at ${func} value 
    of inputParamter is ${param}, cannot confirm type`;
}
function _isStringKey(i) {
    if (_undefinedCheck(i)) {
        // im not going to create a DI Error creation system
        // i should cus this language is dumpsterfire,
        // and it would help with creating and serializing faults.
        // but i won't, this has to end somewhere.
        throw new Error(_typeNullValueErrorMessage(_isStringKey, i));
    }
    if (!_isString(Object.keys(i))) {
        return false;
    }
    return true;
}
function _isObject(i) {
    if (typeof (i) === 'object'){
        return true;
    }
    return false;
}
function _isArray(i) {
    if (Array.isArray(i) || i instanceof Array) {
        return true;
    }
    return false;
}
function Selector(selector) {
    this.selector = selector;
}
Selector.prototype._isString = (function () {
    return _isString(this.selector);
})
function BoolChecker(value) {
    this.value = value;
}
BoolChecker.prototype.check = (function (){
   return isBoolean(this.value);
})
function _jqDestructHelper({ selector: s, parent: p, child: c, attribute: a }) {
   const items = [s, p, c, a];
    return each(items, (i, e) => {
        if (!_undefinedCheck(e)) {
            return _jqObjectDestructHelper(e)
        }
    });
}
//handle wildcard case.
function _jqObjectDestructHelper({ id: i, class: c, css: s,  attribute: a}) {
    let A = {};
    A['id'] = _idSelectorHelper(i);
    A['class'] = isValidClassSelector(_classHandlerhelper(c));
    if (!_undefinedCheck(A['class'] || !_undefinedCheck(A['id']))) {
        A['css'] = _cssHandlerHelper(A, s);
        A['attr'] = _attributeHandlerHelper(A, a);
    } else {
        A['css'] = _cssHandlerHelper(s);
        A['attr'] = _attributeHandlerHelper(a);
    }
    // jq selection is going to find all the elements with the qualified items
    // and return elements
    return A;
}
function _attributeHandlerHelper({ class: c = undefined, id: i = undefined }, attr) {
    if (_isArray(attr)) {
        if (!_undefinedCheck(id)) {
            return document.querySelectorAll(_querySelectorConstructor('attribute',attr,id))
        }
        if (!_undefinedCheck(c)) {
            let a = $(c);
            if (a === undefined) {
                throw new Error("keep on keeping on");
            }
            if (a.attributes.length = attr.length) {
                each(a.attributes, (i, e) => {
                    if (!(e.name === Object.keys(attr[i])[0] && e.value === Object.values(attr[i])[0].toString())) {
                        return i;
                    }
                })
                return (function () {

                })()
            }
            return undefined;
        }
        return document.querySelectorAll(_querySelectorConstructor('attribute', attr));
    }
    throw new Error(_wrongParameterSupplied());
}
function _jqSelection({ id: i, class: c, css: s, attr: a, element: e}) {
    //this should be no throw code.
    const validatedElements = [i, c, s, a, e];
    each()
    
    /*  
        do a builder pattern at the top of abstraction
        var element = new ElementSelector(); 
        element.index('value').css('value').attribute('values').class('value');
        element.parent.index('value').css('value').attribute('values').class('values');
        element.child.index('value').css('value').attribute('values').class('values');

        could eventually start implementing some more in depth searches, eg. child could have more children.
        parent could have more parents or other children could select elements based on their node value.
        something to think about.
        
        someElements.select().each((i,e)=>{
            //do work.
        })
    */
}
//needs to be called from class, id or css selector, will search for items by itself otherwise.
//this needs to be a comma separated string of attributes if htmlElements is empty.
// could be used.... take a deeper look.

function selectByElement(s) {
    if (_isString(s)) {

    }
}

function isValidElement(s) {
}

function elementAsObjectTooString(s) {

}

function elementAsArrayTooString(s) {
    if (_isArray(s) && !_isNestedTooDeep(2)) {
        return each(s, (i,e) => {
            if (_isStirng(s)) {
                
            }
        })
    }
}

function _jqAttributeSelector(htmlElements = undefined, i) {
    if (_undefinedCheck(htmlElements)) {
        return document.querySelectorAll(_querySelectorConstructor('attribute', i));
    }
    const getAttributeIterator = getAttributeIterator(i, attributeAsIterator, attributeAsObject);
    let a = [...(htmlElements).toArray()]
    let b = [];
    b.push(each(a, [...(ind, el) => {
       return each(i, (ind, attributes) => {
           let c = $(el);
           if (c.attr(someObject.keys(0)) == someObject.values(0)) {
               
           }
        })
    }]))
    return each(b, (i, e) => {
        if (_isArray(e)) {
            e.flat();
        }
    }).flat();
}
function getAttributeIterator(i, iteratorfunc, func) {
    if (_isArray(i)) {
        return (function* (i) {
            return iteratorfunc(i)
        })
    }
    else if (_isObject(i)) {
        return (function (i) {
            return func(i)
        });
    }
    throw new Error(_wrongParameterSupplied(getattributeIterator, i))
}
function* attributeAsIterator(i) {
    for (let a = 0; a < i.length; a++) {
        yield i[a];
    }
}
function attributeAsObject(i) {
    return Object.keys(i)[0];
}
function _undefinedCheck(i) {
    if (!i || i === null || i === undefined || i === null) return true;
    return false;
}
function _parentHandlerHelper(p) {
    
}
function _idSelectorHelper(i) {
    if (_undefinedCheck(i)) {
        return undefined;
    }
    if (!validator(_isString, i) && !validator()) {
        //not gonna do some wierd ass logic here.
        throw new Error("id is not stirng")
    }
    return (i.replace(' ', '').indexOf('#') != 0) ? '#' + i.replace(' ', '') : i.replace(' ', '');
}
function isValidClassSelector(s) {
        const classSplitter = {
            [Symbol.split](str) {
                let dot = '.';
                let space = ' ';
                const result = [];
                const dotpos = str.matchAll(dot);
                let spacepos = str.matchAll(space);
                if (dotpos.length < spacepos.length) {
                    result.push([...str.split(' ')])
                    result = each(result, (i, e) => {
                        switch (e[0]) {
                            case ',':
                                const [start, ...rest] = [e];
                                return `${start} .${rest}`
                            case '.':
                                return e;
                            case '':
                                if (isEmptyString(e)) {
                                    return undefined;
                                }
                                return isValidClassSelector(e);
                            case undefined:
                                break;
                            default:
                                return dot + e;
                        }
                        return e.join(' ');
                    })
                }
                return spacepos
            }
        }
    if (_isString(s)) {
        return s.split(classSplitter).join();
    } else if (_isArray(s) && !_isNestedTooDeep(s, 1)) {
        let b = each(s, (i, e) => isString(e));
        if (!_jqBoolArrayHelper(b)) {
            throw new Error('why do you insist on sending me trash...?')
        }
        return each(s, (i, e) => {
            let a = e.replace(' ', '');
            if (!a.startsWith('.')) {
                return '.' + a;
            }
            return e;
        })
    } else if (_isObject(s)) {
        //cus fuck it. no clue what will happen, sure it will fine (:<
        return isValidClassSelector(Object.keys(s));
    }
    return undefined;
}
function isEmptyString(s) {
    if (s === ' ' || s === "") {
        return true;
    }
    return false;
}
function _classHandlerhelper(s) {
    let s1;
    if (_undefinedCheck(s)) {
        return undefined;
    }
    if (Array.isArray(s)) {
        let selectors = each(s, (i, e) => new Selector(e));
        let type = each(selectors, (i, e) => e._isString())
        if (!_jqBoolArrayHelper(type)) {
            throw new Error(`selector member array in 
            selector-object is not comprised of string arrays!`);
        }
        s1 = s.join(" ");
    } else if (!validator(_isString, s)) {
        throw new Error(`selector is not a string!`)
        //need to handle case item being an object laoded with an array field or 
        // or a object loaded with objects of 
    } else if (_isObject(s)) {
        let b = Object.values(s);
        let k=each(b, (i, e) => {
            if (_isString(b)) {
                return true;
            }
        })
        if (_jqBoolArrayHelper(k)) {
            return b.join(' ');
        } else if (_isString(s)) {
            return s
        }
    }
    return undefined;
}
function _jqBoolArrayHelper(bools) {
    let b = each(bools, (i, e) => {
        if (validator((isBoolean, e))) {
            return i;
        }
    }).findIndex(e => e === false)
    if (b > -1) {
        throw new Error(`array at ${jqBitstuffHelper} 
        is not comprised of boolean values!`);
    }
    return (bools.findIndex(e => e === false) > -1) ? false : true;
}
function jqClassInputValidate(input = 'input' || ['input'] || ((param) => 'input') || { input: 'value' }, [...param]) {
    if (_undefinedCheck(input)) {
        throw new Error(`
        Error at${jqClassInputValidate.toString()}
        arguments ${jqClassInputValidate.length} was undefined`);
    }
}
// wrap in another function, it should only take in the object to validate and target to validate as
// if it's not the target it is supposed to be validated as, it should by itself invoke a transformer and
// try to validate... #TODO take another look at this.. /:
function validate(obj, target, transformer = undefined, checker = undefined) {
    if (_undefinedCheck(obj)) {
        throw new Error(_typeNullValueErrorMessage());
    }
    if (_undefinedCheck(func) && _undefinedCheck(transformer)) {
        let a = _typeResolver(obj);
        let b = _typeResolver(target);
    }
}
function _typeResolver(i) {
    let a = _typeResolverHelper(i);
    if (!(a > -1)){
        return undefined;
    }
    return i[a];
}
// only works for implementation of keyvaluepairs, will throw otherwise
// will transform the name into string in resulting obj, the value will
function _cssHandlerHelper({class: c = undefined, id: a = undefined }, i) {
    if (_undefinedCheck(i)) {
        throw new Error(_typeNullValueErrorMessage());
    }
    if (!_isArray(i)) {
        throw new Error(_wrongParameterSupplied());
    }
    if (!_undefinedCheck(a)) {
        return _querySelectorConstructor('css', i, a);

    } else if (!_undefinedCheck(c)) {
        return _querySelectorConstructor('css', i, c);
    }
    //should check if is object and try to transpose it to a array.
    if (_isObject(i) && !_isNestedTooDeep(i, 1)) {
        let b = {
            class: c,
            id: a
        }
        return _cssHandlerHelper(b, [...i]);
    }
    throw new Error(_wrongParameterSupplied())
    return each(i, (i, e) => {
        if (_isString(e)) {
            return _extractCssValues(e, a);
        } else if (_isObject(e) && (_isKeyString(e) || _undefinedCheck(e))) {
            return e;
        }
    }).flat();
}
function _extractCssValues({ values: e }, fromElement = undefined) {
    if (!_isString(e)){
        return undefined;
    }
    //jquery interface case
    let a = e.trim();
    let reg = /[^:]*:[^;]*;/gmi;
    let a = a.match(reg);
    if (a.length > 1) {
        return each(a, (i, e) => {
            const b = {};
            const l = e.split(":");
            return b[`${l[0]}`] = l[1];
        })
    }
    const b = {};
    return b[`${a[0]}`] = a[1];
}
const querySelectorObject = {
    type: 'css' | 'attribute',
    values: 'values'
}
// keyvaluevalue pair of attributes. or attribute object....
// if object, run Object.key if array run each...
// need to make sure that the elements are not nested ergo transpost into array and flatten
// and that each element does not have more fields than one.
function _querySelectorConstructor(type, values, fromElement=undefined) {
    let a = {
        type: type,
        values: values,
    }
    if (!_undefinedCheck(fromElement)) {
        return `${fromElement}${_querySelectorConstructor(a)}`;
    }
    return _querySelectorConstructor(a);
}
function _querySelectorConstructor({ type: t = undefined, values: v = undefined }) {
    switch (t) {
        case 'css':
            return attributeBuild('style', v);
        case 'attribute':
            return each(v, (i, e) => {
                return attributeBuild(Object.keys(e)[0], Object.values(e)[0]);
            }).join('');
        default:
            return attributeBuild(Object.keys[0], Objec.values(e)[0]);
    }
    const attributeBuild = (function (attribute, [...values] = undefined) {
        if (_isArray(values) && !_undefinedCheck(attribute)) {
            return `[${attribute}]=${values.join(' ')}`;
        } else if (!_undefinedCheck(attribute) && _undefinedCheck(values)) {
            return `[${attribute}]`;
        } else if (_undefinedCheck(attribute) && _undefinedCheck(values)) {
            throw new Error(_typeNullValueErrorMessage());
        }
        return `[${attribute}]=${value}`;
    })
}
function _querySelectorConstructor(type, values) {

    return _querySelectorConstructor({ type, values });
}
//  piss on the tree algorithmt :),
//  this will throw if object has function fields
//  also sets and maps are not handled....
//  #TODO: implment set types, function diversion and 
//          map types.
function _isNestedTooDeep(i, max) {
    const GUUID = createGUUID();
    let clone = Object.assign(clone, i);
    if (_undefinedCheck(i) && _undefinedCheck(max)) {
        throw new Error(_typeNullValueErrorMessage())
    }
    return r(clone, 0, max);
    const r = (function (clone, depth, max) {
        // only for clarities sake, as the function
        // will default down to zero at the end.
        if (_undefinedCheck(clone) && (depth > 0)) {
            return (depth > max)
        }
        let a;
        if (_undefinedCheck(clone[GUUID])) {
            a = Object.keys(clone);
            clone[GUUID] = a.length -1;
        }
        if (clone[GUUID] <= 0) {
            return r(clone, depth - 1, max);
            console.log(`circular reference found::
            Object::depth::${depth}, keys left at current 
            node${clone[GUUID]}`);
        }
        if (_isArray(clone)) {
            let a = _nestedArrayDiscovery(clone);
            return r(a['array'][a['index']], depth+1, max);
        }
        if (a.length == 0) {
            return (depth > max)
        }
        if (clone[GUUID] >= 0) {
            for (let j = clone[GUUID]; j >= 0; j--) {
                clone[GUUID] -= clone[GUUID];
                if (clone[GUUID] >= -1 && r(clone[a[j]], depth + 1, max)) {
                    return true;
                }
            }
        }
        return false;
    })
    const createGUUID = (function () {
         return crypto.randomUUID();
    })
}
//Arrays nested in Arrays will be treated as transparent arrays and flattened.
//returns the index where object is found in recursevly flattened array.
function _nestedArrayDiscovery(i) {
    if (_undefinedCheck(i)) {
        throw new Error(_typeNullValueErrorMessage());
    }
    if (!_isArray(i)) {
        throw new Error(_wrongParameterSupplied());
    }
    return k(i, 0);
    const k = (function (a, depth) {
        let i = a.findIndex(e => typeof (e) === 'object');
        if (i > -1 && _isArray(a)) {
            let b = new Array(a.flat());
           return k(b, depth+1);
        }
        return {index: i, array: a};
    })
}
function _wrongParameterSupplied(func, i) {
    if (_undefinedCheck(func) || _undefinedCheck(i)) {
        return 'Wrong type parameter supplied to Transformer'
    }
    const re = new RegExp('((_)|(_jq)+(:?*(:!Trans*)))');
    return `Wrong parameter type ${typeof (i)} was supplied 
    to function ${func}, was expecting:: ${func.toString().match(re)}`
}
    const types = ['object',
        'string',
        'number',
        'undefined',
        'null',
        'boolean']; 
function _typeResolverHelper(item) {

    return each(types, (i, e) => {
        return _typeOfChecker(item, e);
    }).indexOf(e, e => !(undefined));
}
function _typeOfChecker(item, base) {
    if (typeof (item) === base) {
        return item;
    }
}

function validator(func = ((object)=> false), object, transformer, target) {
    if (func && func(object)) {
        return true;
    } else if(func && transformer){
        if (!func(object)) {
            return (function (object, target, transformer) {
                let a = transformer(object);
                if ((typeof (a) === typeof (undefined)) || !(typeof (a) === typeof (target) || !(a instanceof target))) {
                    debugger
                    console.log(`transformer${transformer.toString()}function returned ${typeof (a)} in 
                    validator, target was${ typeof(target)}, transformer did not successfully transform.`);
                    return (function (target, a) {
                        if (target === undefined || typeof (target) === 'undefined') {
                            debugger
                            console.log(`target type was not supplyied cannot 
                            confirm if the transformation was successfull`)
                            return a;
                        } else {
                            debugger
                            console.log(`transformation to target type was not
                            successfull`)
                            return undefined;
                        }
                    })(target, a);
                }
                return a;
            })(object, target, transformer)
        }
        return false;
    }
    return false;
}
function validator({ func: f, object: o, transformer: tr, target: ta }) {
    return validator(f, o, tr, ta);
}
function Move(items) {
    each(items, (function (item) {
        if (item instanceof jQuery) {
           return jMove(item);
        } else {
           return jMove($(item));
        }
    }))
}
function jMove(item) {
    let transpose = item.attr("data-transpose-top");
    return item.css(transpose);
}
function isBoolean(i) {
    if (typeof (i) === 'boolean' || i instanceof Boolean) {
        return true;
    }
    return false;
}
function each(items, func) {
    if (!Array.isArray(items)) {
        throw "Object is not a Array!";
    }
    let check = {
        hold: items.length,
    }
    let pHold = new Array();
    const returnConstructor = (function (i, b = pHold, checker = check) {
        let a = i.next();
        if (a.value == undefined) {
            checker['hold'] -= 1;
        }
        b.push(a.value);
        if (checker['hold'] == 0 || a.done === true) {
            return (function (b, checker) {
                if (checker['hold'] > 0) {
                    return b;
                }
            })(b, checker);
        }
        return returnConstructor(i, b, checker)
    });
    const Iterator = (function* (items, func) {
        for (let i = items.length - 1; i >= 0; i--) {
            yield func(i, items[i]);
        }
    })
    return returnConstructor(Iterator(items, func), pHold, check);
}
function argumentDiscovery(func){
    let a = new String(func.toString()).replace(' ', '');
    return new Array(a.slice(a.IndexOf('(')[0], a.firstIndexOf(')')[1]));
}
(function () {
    function somefunction(takes) {
        return returntakes(somepar, (function () { console.log("this works") }));
    }
    somefunction((function () { console.log("does this work?") }))();
    const Items = {
            
    };
})