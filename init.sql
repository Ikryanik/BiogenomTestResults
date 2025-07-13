--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5 (Debian 17.5-1.pgdg120+1)
-- Dumped by pg_dump version 17.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: food; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.food (
    id bigint NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.food OWNER TO biogenomuser;

--
-- Name: food_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.food ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.food_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: food_influence; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.food_influence (
    food_id bigint NOT NULL,
    health_indicator_id bigint NOT NULL,
    substance_amount numeric NOT NULL,
    id bigint NOT NULL
);


ALTER TABLE public.food_influence OWNER TO biogenomuser;

--
-- Name: food_influence_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.food_influence ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.food_influence_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: food_supplement; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.food_supplement (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description character varying
);


ALTER TABLE public.food_supplement OWNER TO biogenomuser;

--
-- Name: food_supplement_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.food_supplement ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.food_supplement_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: food_supplement_image; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.food_supplement_image (
    id bigint NOT NULL,
    food_supplement_id bigint NOT NULL,
    url character varying NOT NULL
);


ALTER TABLE public.food_supplement_image OWNER TO biogenomuser;

--
-- Name: food_supplement_image_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.food_supplement_image ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.food_supplement_image_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: food_supplement_influence; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.food_supplement_influence (
    food_supplement_id bigint NOT NULL,
    health_indicator_id bigint NOT NULL,
    substance_amount numeric NOT NULL,
    id bigint NOT NULL
);


ALTER TABLE public.food_supplement_influence OWNER TO biogenomuser;

--
-- Name: food_supplement_influence_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.food_supplement_influence ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.food_supplement_influence_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: health_indicator; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.health_indicator (
    id bigint NOT NULL,
    name character varying NOT NULL,
    norm numeric NOT NULL
);


ALTER TABLE public.health_indicator OWNER TO biogenomuser;

--
-- Name: health_indicator_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.health_indicator ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.health_indicator_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: health_indicator_result; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.health_indicator_result (
    test_result_id bigint NOT NULL,
    health_indicatorid bigint NOT NULL,
    result numeric NOT NULL,
    id bigint NOT NULL
);


ALTER TABLE public.health_indicator_result OWNER TO biogenomuser;

--
-- Name: health_indicator_result_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.health_indicator_result ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.health_indicator_result_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: necessary_food; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.necessary_food (
    test_result_id bigint NOT NULL,
    food_id bigint NOT NULL,
    id bigint NOT NULL
);


ALTER TABLE public.necessary_food OWNER TO biogenomuser;

--
-- Name: necessary_food_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.necessary_food ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.necessary_food_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: necessary_food_supplement; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.necessary_food_supplement (
    test_result_id bigint NOT NULL,
    food_supplement_id bigint NOT NULL,
    id bigint NOT NULL
);


ALTER TABLE public.necessary_food_supplement OWNER TO biogenomuser;

--
-- Name: necessary_food_supplement_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.necessary_food_supplement ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.necessary_food_supplement_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: test; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.test (
    id bigint NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.test OWNER TO biogenomuser;

--
-- Name: test_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.test ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.test_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: test_result; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public.test_result (
    id bigint NOT NULL,
    name character varying NOT NULL,
    test_id bigint NOT NULL,
    user_id bigint NOT NULL
);


ALTER TABLE public.test_result OWNER TO biogenomuser;

--
-- Name: test_result_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public.test_result ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.test_result_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: user; Type: TABLE; Schema: public; Owner: biogenomuser
--

CREATE TABLE public."user" (
    id bigint NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."user" OWNER TO biogenomuser;

--
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: biogenomuser
--

ALTER TABLE public."user" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: food; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.food (id, name) FROM stdin;
1	Скумбрия
2	Морской еж
3	Арбуз
4	Роллы
5	Пицца
\.


--
-- Data for Name: food_influence; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.food_influence (food_id, health_indicator_id, substance_amount, id) FROM stdin;
1	3	23	1
1	5	11	2
2	3	56	3
3	4	12	4
3	5	3	5
\.


--
-- Data for Name: food_supplement; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.food_supplement (id, name, description) FROM stdin;
1	Детримакс	лучшие капли на свете
2	Спортпит	ты качок
3	Кора дерева БАД	почти натурально
4	Аскорбинка	лучший друг
\.


--
-- Data for Name: food_supplement_image; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.food_supplement_image (id, food_supplement_id, url) FROM stdin;
\.


--
-- Data for Name: food_supplement_influence; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.food_supplement_influence (food_supplement_id, health_indicator_id, substance_amount, id) FROM stdin;
1	1	22	1
1	4	2	2
3	3	22	3
2	3	43	4
4	2	89	5
\.


--
-- Data for Name: health_indicator; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.health_indicator (id, name, norm) FROM stdin;
1	Витамин д	122
2	Витамин с	34
3	Йод	12
4	Ретинол	78
5	Гемоглобин	126
\.


--
-- Data for Name: health_indicator_result; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.health_indicator_result (test_result_id, health_indicatorid, result, id) FROM stdin;
1	1	21	1
1	2	2	2
1	3	0	3
1	4	99	4
1	5	800	5
\.


--
-- Data for Name: necessary_food; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.necessary_food (test_result_id, food_id, id) FROM stdin;
1	3	1
1	1	2
1	4	3
1	2	4
\.


--
-- Data for Name: necessary_food_supplement; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.necessary_food_supplement (test_result_id, food_supplement_id, id) FROM stdin;
1	1	1
1	3	2
1	4	3
\.


--
-- Data for Name: test; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.test (id, name) FROM stdin;
1	Тест на здоровье
\.


--
-- Data for Name: test_result; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public.test_result (id, name, test_id, user_id) FROM stdin;
1	Первый в жизни	1	1
\.


--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: biogenomuser
--

COPY public."user" (id, name) FROM stdin;
1	Вениамин
\.


--
-- Name: food_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.food_id_seq', 5, true);


--
-- Name: food_influence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.food_influence_id_seq', 5, true);


--
-- Name: food_supplement_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.food_supplement_id_seq', 4, true);


--
-- Name: food_supplement_image_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.food_supplement_image_id_seq', 1, false);


--
-- Name: food_supplement_influence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.food_supplement_influence_id_seq', 5, true);


--
-- Name: health_indicator_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.health_indicator_id_seq', 5, true);


--
-- Name: health_indicator_result_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.health_indicator_result_id_seq', 5, true);


--
-- Name: necessary_food_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.necessary_food_id_seq', 4, true);


--
-- Name: necessary_food_supplement_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.necessary_food_supplement_id_seq', 3, true);


--
-- Name: test_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.test_id_seq', 1, true);


--
-- Name: test_result_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.test_result_id_seq', 1, true);


--
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: biogenomuser
--

SELECT pg_catalog.setval('public.user_id_seq', 1, true);


--
-- Name: food_influence food_influence_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_influence
    ADD CONSTRAINT food_influence_pk PRIMARY KEY (id);


--
-- Name: food_influence food_influence_un; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_influence
    ADD CONSTRAINT food_influence_un UNIQUE (food_id, health_indicator_id);


--
-- Name: food food_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food
    ADD CONSTRAINT food_pk PRIMARY KEY (id);


--
-- Name: food_supplement_image food_supplement_image_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_image
    ADD CONSTRAINT food_supplement_image_pk PRIMARY KEY (id);


--
-- Name: food_supplement_influence food_supplement_influence_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_influence
    ADD CONSTRAINT food_supplement_influence_pk PRIMARY KEY (id);


--
-- Name: food_supplement_influence food_supplement_influence_un; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_influence
    ADD CONSTRAINT food_supplement_influence_un UNIQUE (food_supplement_id, health_indicator_id);


--
-- Name: food_supplement food_supplement_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement
    ADD CONSTRAINT food_supplement_pk PRIMARY KEY (id);


--
-- Name: health_indicator health_indicator_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.health_indicator
    ADD CONSTRAINT health_indicator_pk PRIMARY KEY (id);


--
-- Name: health_indicator_result health_indicator_result_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.health_indicator_result
    ADD CONSTRAINT health_indicator_result_pk PRIMARY KEY (id);


--
-- Name: health_indicator_result health_indicator_result_un; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.health_indicator_result
    ADD CONSTRAINT health_indicator_result_un UNIQUE (test_result_id, health_indicatorid);


--
-- Name: necessary_food necessary_food_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food
    ADD CONSTRAINT necessary_food_pk PRIMARY KEY (id);


--
-- Name: necessary_food_supplement necessary_food_supplement_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food_supplement
    ADD CONSTRAINT necessary_food_supplement_pk PRIMARY KEY (id);


--
-- Name: necessary_food_supplement necessary_food_supplement_un; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food_supplement
    ADD CONSTRAINT necessary_food_supplement_un UNIQUE (test_result_id, food_supplement_id);


--
-- Name: necessary_food necessary_food_un; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food
    ADD CONSTRAINT necessary_food_un UNIQUE (test_result_id, food_id);


--
-- Name: test test_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.test
    ADD CONSTRAINT test_pk PRIMARY KEY (id);


--
-- Name: test_result test_result_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.test_result
    ADD CONSTRAINT test_result_pk PRIMARY KEY (id);


--
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- Name: food_influence food_influence_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_influence
    ADD CONSTRAINT food_influence_fk FOREIGN KEY (food_id) REFERENCES public.food(id);


--
-- Name: food_influence food_influence_fk2; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_influence
    ADD CONSTRAINT food_influence_fk2 FOREIGN KEY (health_indicator_id) REFERENCES public.health_indicator(id);


--
-- Name: food_supplement_image food_supplement_image_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_image
    ADD CONSTRAINT food_supplement_image_fk FOREIGN KEY (food_supplement_id) REFERENCES public.food_supplement(id);


--
-- Name: food_supplement_influence food_supplement_influence_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_influence
    ADD CONSTRAINT food_supplement_influence_fk FOREIGN KEY (food_supplement_id) REFERENCES public.food_supplement(id);


--
-- Name: food_supplement_influence food_supplement_influence_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.food_supplement_influence
    ADD CONSTRAINT food_supplement_influence_fk_1 FOREIGN KEY (health_indicator_id) REFERENCES public.health_indicator(id);


--
-- Name: health_indicator_result health_indicator_result_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.health_indicator_result
    ADD CONSTRAINT health_indicator_result_fk FOREIGN KEY (test_result_id) REFERENCES public.test_result(id);


--
-- Name: health_indicator_result health_indicator_result_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.health_indicator_result
    ADD CONSTRAINT health_indicator_result_fk_1 FOREIGN KEY (health_indicatorid) REFERENCES public.health_indicator(id);


--
-- Name: necessary_food necessary_food_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food
    ADD CONSTRAINT necessary_food_fk FOREIGN KEY (test_result_id) REFERENCES public.test_result(id);


--
-- Name: necessary_food necessary_food_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food
    ADD CONSTRAINT necessary_food_fk_1 FOREIGN KEY (food_id) REFERENCES public.food(id);


--
-- Name: necessary_food_supplement necessary_food_supplement_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food_supplement
    ADD CONSTRAINT necessary_food_supplement_fk FOREIGN KEY (test_result_id) REFERENCES public.test_result(id);


--
-- Name: necessary_food_supplement necessary_food_supplement_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.necessary_food_supplement
    ADD CONSTRAINT necessary_food_supplement_fk_1 FOREIGN KEY (food_supplement_id) REFERENCES public.food_supplement(id);


--
-- Name: test_result test_result_fk; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.test_result
    ADD CONSTRAINT test_result_fk FOREIGN KEY (test_id) REFERENCES public.test(id);


--
-- Name: test_result test_result_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: biogenomuser
--

ALTER TABLE ONLY public.test_result
    ADD CONSTRAINT test_result_fk_1 FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- PostgreSQL database dump complete
--

